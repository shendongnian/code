    public class ValidateLookupAttribute : ValidationAttribute
    {
        //Use this to identify what validation needs to be performed
        public ValidationType ValidationType { get; private set; }
        public ValidateLookupAttribute(ValidationType validationType)
        {
            ValidationType = validationType;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Use the validation factory to get the validator associated
            //with the validator type
            ValidatorFactory validatorFactory = new ValidatorFactory();
            var Validator = validatorFactory.GetValidator(ValidationType);
            //Execute the validator
            bool isValid = Validator.Validate(value);
            //Validation is successful, return ValidationResult.Succes
            if (isValid)
                return ValidationResult.Success;
            else //Return validation error
                return new ValidationResult(Validator.ErrorMessage);
        }
    }
