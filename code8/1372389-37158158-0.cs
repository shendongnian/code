    [AttributeUsage(AttributeTargets.Property)]
    public class ComplexLogicAttribute: ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (MyModel)validationContext.ObjectInstance;
    
            if (IsValueValidForGivenObject(model, Convert.ToString(value)))
                return ValidationResult.Success;
    
            // Or your own error message...
            return new ValidationResult(FormatErrorMessage(null));
        }
    
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "complexlogic",
                ErrorMessage = ErrorMessage
            };
    
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
