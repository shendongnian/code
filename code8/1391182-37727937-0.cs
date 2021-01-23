        public class SomeEntity
        {
            [MustBeLessThanDate(nameof(End))]
            public DateTime Beginning { get; set; }
            public DateTime End { get; set; }
        }
        public class MustBeLessThanDateAttribute : ValidationAttribute
        {
            private readonly string _otherPropertyName;
            public MustBeLessThanDateAttribute(string otherPropertyName)
            {
                _otherPropertyName = otherPropertyName;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var containerType = validationContext.ObjectInstance.GetType();
                var field = containerType.GetProperty(_otherPropertyName);
                var otherValue = (DateTime) field.GetValue(validationContext.ObjectInstance, null);
                var thisValue = (DateTime) value;
                return thisValue < otherValue
                    ? ValidationResult.Success
                    : new ValidationResult("Value is not less than other value");
            }
        }
