    public class ValidatorFactory
    {
        private Dictionary<ValidationType, IValidator> validators = new Dictionary<ValidationType, IValidator>();
        public ValidatorFactory()
        {
            validators.Add(ValidationType.City, new CityValidator());
        }
        public IValidator GetValidator(ValidationType validationType)
        {
            return this.validators[validationType];
        }
    }
 
