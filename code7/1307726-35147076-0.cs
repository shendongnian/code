    public class ValidateUserName: ValidationAttribute
    {
        string userName;
        public ValidateUserName(string userName)
        {
            this.userName = userName;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        if (UserNameExist())
        {
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
        return null;
        }
    }
