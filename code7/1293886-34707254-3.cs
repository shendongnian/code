    public class LengthValidationRule : ValidationRule
    {
        public int RequiredLength { get; set; }
    
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var text = (string)value;
    
            if(string.IsNullOrEmpty(text) || text.Length < RequiredLength)
            {
                return new ValidationResult(false, "Text should be at least four characters long");
            }
    
            return ValidationResult.ValidResult;
        }
    }
