    public class AppMaxLengthAttribute : MaxLengthAttribute, IClientValidatable
    {
        public AppMaxLengthAttribute(string configName)
        : base(int.Parse(WebConfigurationManager.AppSettings[configName]))
        {
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "maxlength"
            };
            rule.ValidationParameters.Add("max", this.Length);
            yield return rule;
        }
    }
