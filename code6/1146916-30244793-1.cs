    public class UltimateValidator
    {
        private IValidate[] validators
        public UltimateValidator(IValidate[] validators)
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
