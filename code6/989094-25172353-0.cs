    public class UserNameExists : ValidationAttribute
    {
     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
     {
      // do your look-up check and return ValidationResult.Success accordingly.
     }
    }
