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
    
                // Mobile number must contain 7 characters
                if (phone.PrefixId > 64)
                {
                    if (phone.Digits.Length != 7)
                    {
                        this.ErrorMessageSource = new StaticStringSource("Mobile number must contain 7 characters");
                        return false;
                    }
                }
                // Numbers in 2nd city must contain 7 characters
                else if (phone.PrefixId == 2)
                {
                    if (phone.Digits.Length != 7)
                    {
                        this.ErrorMessageSource = new StaticStringSource("Numbers in 2nd city must contain 7 characters");
                        return false;
                    }
                }
                // Numbers in other cities must contain 5 characters
                else
                {
                    if (phone.Digits.Length != 5)
                    {
                        this.ErrorMessageSource = new StaticStringSource("Numbers in other cities must contain 5 characters");
                        return false;
                    }
                }
    
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
