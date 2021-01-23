    public class MyValidateAttribute : ValidationAttribute
    {
        public Type ValidateType { get; private set; }
        private IValidatorCommand _command;
        public MyValidateAttribute(Type type)
        {
            ValidateType = type;            
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _command = ValidatorFactory.GetCommand(ValidateType);
            _command.Input = value;
            var result = _command.Execute();
            if (result.IsValid)
                return ValidationResult.Success;
            else
                return new ValidationResult(result.ErrorMessage);
        }
    }
