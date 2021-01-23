    public class ValidateOfAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (SwedishPersonalIdentityNumber.TryParse((string)value, out var personalIdentityNumber))
            {
                if(personalIdentityNumber.GetAge() >= 18) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Du måste vara minst 18 år gammal.");
                }
            }
            return new ValidationResult("Ogiltigt personnummer.");
        }
    }
