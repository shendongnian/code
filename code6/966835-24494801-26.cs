    public class SerialNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string serialNumberPart = value.ToString();
            return (serialNumberPart.All(c => '0' <= c && c <= '9')) ?
                (serialNumberPart.Length == 5) ?
                     ValidationResult.ValidResult :
                     new ValidationResult(false, "Serial number part must be 5 numbers") :
                new ValidationResult(false, "Invalid characters in serial number part");
        }
    }
