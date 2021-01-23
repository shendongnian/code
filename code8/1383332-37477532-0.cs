    public class Over18Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string message = String.Format("The {0} field is invalid.", validationContext.DisplayName ?? validationContext.MemberName);
    
            if (value == null)
                return new ValidationResult(message);
    
            DateTime date;
            try { date = Convert.ToDateTime(value); }
            catch (InvalidCastException e) { return new ValidationResult(message); }
    
            if (DateTime.Today.AddYears(-18) >= date)
                return ValidationResult.Success;
            else
                return new ValidationResult("You must be 18 years or older.");
        }
    }
