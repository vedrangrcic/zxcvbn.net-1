﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace zxcvbn.net
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class PasswordEntropy : ValidationAttribute
    {
        public int _entropy { get; private set; }
        public PasswordEntropy(int entropy) : base("Password needs to be stronger") { _entropy = entropy; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as String;
            if (password == null) return new ValidationResult("A password is required.");
            if (Zxcvbn.Entropy(password) < _entropy)
            {
                return new ValidationResult("Password is not strong enough.");
            }

            return ValidationResult.Success;
        }
    }

}
