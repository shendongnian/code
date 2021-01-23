    public class MyValidateTime: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {                 
            DateTime dt;
            if (DateTime.TryParseExact((string)value, new[] { "hh:mm tt", "h:mm tt" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                return ValidationResult.Success;
            else
                return new ValidationResult("Correct time formats: 01:00 AM or 1:00 AM");
        }
    }
