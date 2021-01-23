    public class RequiredIfOtherProperty : ValidationAttribute
    {
        private readonly string _otherPropertyName;
        private readonly string _compareValue;
        public RequiredIfOtherProperty(string otherPropertyName, string compareValue)
        {
            _otherPropertyName = otherPropertyName;
            _compareValue = compareValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (otherProperty == null)
            {
                return new ValidationResult($"Property '{_otherPropertyName}' does not exist");
            );
        }
        var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);
        if (!_compareValue.Equals(otherPropertyValue))
        {
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
        return null;
    }
