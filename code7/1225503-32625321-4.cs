    public class ValidateOfAge: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {                 
            string RegExForValidation = @"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$";
            string date = Regex.Match((string)value, RegExForValidation).Groups["date"].Value;
            DateTime dt;
            if (DateTime.TryParseExact(date, new[] { "yyMMdd", "yyyyMMdd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                if (IsOfAge(dt))
                    return ValidationResult.Success;
            return new ValidationResult("Personnummer anges med 10 siffror (yymmddnnnn)");
        }
    }
