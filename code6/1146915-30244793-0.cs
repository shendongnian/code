    public class ValidateAll
    {
        private IValidate[] validators
        public ValidateAll(IValidate[] validators)
        {
             this.validators = validators;
        }
        public bool ValidateAll()
        {
              foreach (var validator in validators)
              {
                     if (validator.Validate())
                     {
                          // etc.
                     }
              }
        }
    }
