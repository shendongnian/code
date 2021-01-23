    public class IPUniqueValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var IP = value.ToString();
                var isValid = false;
    
                // Validation code...
                    
                if (isValid)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Error occurred. The Same IP is already assigned.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
