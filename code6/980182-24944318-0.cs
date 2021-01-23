    public class GreaterThanAttribute : ValidationAttribute
    {
        public string PropertyNameToCompare { get; set; }
    
        public GreaterThanAttribute(string propertyNameToCompare)
        {
            PropertyNameToCompare = propertyNameToCompare;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyToCompare = validationContext.ObjectType.GetProperty(PropertyNameToCompare);
            if (propertyToCompare == null)
            {
                return new ValidationResult(
                    string.Format("Invalid property name '{0}'", PropertyNameToCompare));
            }
            var valueToCompare = propertyToCompare.GetValue(validationContext.ObjectInstance, null);
    
            bool valid;
    
            if (value is decimal && valueToCompare is decimal)
            {
                valid = ((decimal) value) > ((decimal) valueToCompare);
            }
            //TODO: Other types
            else
            {
                return new ValidationResult("Compared properties should be numeric and of the same type.");
            }
    
            if (valid)
            {
                return ValidationResult.Success;
            }
    
            return new ValidationResult(
                string.Format("{0} must be greater than {1}",
                    validationContext.DisplayName, PropertyNameToCompare));
        }
    }
