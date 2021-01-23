    class RequiredValidationRule : ValidationRule
    {
        public bool IsRequired { get; set; }
        public bool IsMandatory { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var content = value as String;
            if (content != null)
            {
                if (IsRequired && String.IsNullOrWhiteSpace(content))
                    return new ValidationResult(false, "Required content");
                if (IsMandatory && String.IsNullOrEmpty(content))
                    return new ValidationResult(false, "Required content");
            }
            return ValidationResult.ValidResult;
        }
    }
