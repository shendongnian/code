    public class WorkEmailAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            string[] personalEmailDomains = new string[] { "@gmail.com", "@yahoo.com", "@hotmail.com", "@outlook.com" };
            string valueString = value.ToString();
            foreach (string personalEmailDomain in personalEmailDomains)
            {
                if (valueString.Contains(personalEmailDomain))
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return null;
        }
    }
