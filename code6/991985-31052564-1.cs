    using System.Collections.Generic;
    using System.Web.Mvc;
    public class MaximumLengthValidator : DataAnnotationsModelValidator
    {
        private string _errorMessage;
        private MaximumLengthAttribute _attribute;
        public MaximumLengthValidator(ModelMetadata metadata, ControllerContext context, MaximumLengthAttribute attribute)
        : base(metadata, context, attribute)
        {
            _errorMessage = attribute.FormatErrorMessage(metadata.GetDisplayName());
            _attribute = attribute;
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                // Uses MVC maxlength validator (but with a custom message from MaximumLength)
                ErrorMessage = this._errorMessage,
                ValidationType = "maxlength"
            };
            rule.ValidationParameters.Add("max", _attribute.Length);
            yield return rule;
        }
    }
