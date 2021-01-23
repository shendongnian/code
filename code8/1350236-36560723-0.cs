    public class VerificationCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string code = (string)value;
            Guid userId = Guid.Empty;
    
            PropertyInfo userIdProperty = validationContext.ObjectType.GetProperty("UserId");
            if (userIdProperty != null)
                userId = (Guid)userIdProperty.GetValue(validationContext.ObjectInstance);
    
            // See if we're confirming email via link
            if (userId == Guid.Empty)
                userId = MyProject.Identity.Client.GetUser().Id;
    
            if (!string.IsNullOrWhiteSpace(code) && !MyProject.Identity.Client.VerifyUserEmail(userId, code))
                return new ValidationResult("Invalid email verification code.");
                
            return null; // Default for empty string
        }
    }
