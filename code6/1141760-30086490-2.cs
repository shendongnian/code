    namespace <YourNameSpace>.ValidationRules
    {
        public class DateRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                return new ValidationResult(value is DateTime || value == null, null);
            }
        }
    }
