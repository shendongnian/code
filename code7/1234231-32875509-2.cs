    public class MustBeFilledAttribute : ValidationAttribute, IClientValidatable // IClientValidatable for client side Validation
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(null));
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "mustbefilled",
                ErrorMessage = ErrorMessage //Added
            };
            modelClientValidationRule.ValidationParameters.Add("param", metadata.DisplayName); //Added
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
