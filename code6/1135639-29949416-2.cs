    public class MustFitToPhonePrefix<TModel, TProperty> : PropertyValidator, IClientValidatable
        {
            private string dependencyElement;
    
            public MustFitToPhonePrefix(Expression<Func<TModel, TProperty>> expression)
                : base("Format is wrong")
            {
                dependencyElement = (expression.Body as MemberExpression).Member.Name;
            }
    
            // Server side validation
            protected override bool IsValid(PropertyValidatorContext context)
            {
                // Instance of the class which contains property which must be validated 
                var phone = context.ParentContext.InstanceToValidate as PhoneDetail;
    
                ...
                // Custom logic
                ...
    
                // Everything is valid
                return true;
            }
    
            // Generate jquery unobtrusive attributes
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                var rule = new ModelClientValidationRule
                {
                    ErrorMessage = this.ErrorMessageSource.GetString(), // default error message
                    ValidationType = "fittoprefix" // name of the validatoin which will be used inside unobtrusive library
                };
    
                rule.ValidationParameters["prefixelement"] = dependencyElement; // html element which includes prefix information
                yield return rule;
            }
