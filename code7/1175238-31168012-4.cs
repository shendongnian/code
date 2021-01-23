    public class ValidateLookupAttribute : ValidationAttribute
    {
        public ValidationType ValidationType { get; private set; }
        public ValidateLookupAttribute(ValidationType validationType)
        {
            ValidationType = validationType;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidatorFactory validatorFactory = new ValidatorFactory();
            var Validator = validatorFactory.GetValidator(ValidationType);
            bool isValid = Validator.Validate(value);
            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult(Validator.ErrorMessage);
        }
    }
