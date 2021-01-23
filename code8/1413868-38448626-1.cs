    public class TotalAttributesLengthEqualToAttribute : ValidationAttribute
    {
        private string[] _properties;
        private int _expectedLength;
        public TotalAttributesLengthEqualToAttribute(int expectedLength, params string[] properties)
        {
            ErrorMessage = "Wrong total length";
            _expectedLength = expectedLength;
            _properties = properties;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_properties == null || _properties.Length < 1)
            {
                return new ValidationResult("Wrong properties");
            }
            int totalLength = 0;
            foreach (var property in _properties)
            {
                var propInfo = validationContext.ObjectType.GetProperty(property);
                if (propInfo == null)
                    return new ValidationResult($"Could not find {property}");
                var propValue = propInfo.GetValue(validationContext.ObjectInstance, null) as string;
                if (propValue == null)
                    return new ValidationResult($"Wrong property type for {property}");
                totalLength += propValue.Length;
            }
            if (totalLength != _expectedLength)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
