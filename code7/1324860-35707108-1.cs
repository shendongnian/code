    public class DateGreaterThanAttribute : 
                        ValidationAttribute, 
                        IClientValidatable 
    {
    
        public IEnumerable<ModelClientValidationRule>
            GetClientValidationRules(ModelMetadata metadata,
                                     ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("other", OtherProperty);
            rule.ValidationType = "greaterdate";
            yield return rule;
        }
