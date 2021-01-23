Figured out that I was implementing the wrong type of DataAnnotationsModelValidator
I should have been using the one from the System.Web.Http.Validation.Validators namespace. Like this:
    public class CustomRequiredAttributeAdapter : DataAnnotationsModelValidator
    {
        public CustomRequiredAttributeAdapter(IEnumerable<ModelValidatorProvider> validatorProviders, ValidationAttribute attribute)
        : base(validatorProviders, attribute)
        {
            attribute.ErrorMessage = "{0} is required.";
        }
    }
