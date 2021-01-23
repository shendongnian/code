     public class NameValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                if (string.IsNullOrWhiteSpace(((string)value)))
                {
                    return new ValidationResult(false, "Must not be empty");
                   ButtonSave.IsEnabled = false;
                }
                return new ValidationResult(true, null);
            }
        }
