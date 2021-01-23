        public class EqualsValidationAttribute : ValidationAttribute
    {
        string propertyToCompare;
        public EqualsValidationAttribute(string propertyToCompare)
        {
            this.propertyToCompare = propertyToCompare;
        }
        public EqualsValidationAttribute(string propertyToCompare,string errorMessage):this(propertyToCompare)
        {
            this.ErrorMessage = propertyToCompare;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propInfo=validationContext.ObjectInstance.GetType().GetProperty(propertyToCompare);
            if (propInfo != null)
            {
                var propValue=propInfo.GetValue(validationContext.ObjectInstance);
                if(value!=null && propValue!=null && !string.IsNullOrEmpty(value.ToString()) && !string.IsNullOrEmpty(propValue.ToString()) //if either one is empty dont Validate
                    && (value.ToString() != propValue.ToString()))
                    return new ValidationResult(ErrorMessage);
            } 
            else
                throw new NullReferenceException("propertyToCompare must be the name of property to compare");
            return ValidationResult.Success;
        } 
    }
