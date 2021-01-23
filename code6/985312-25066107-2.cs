    public IEnumerable<ModelClientValidationRule> GetClientValidationRules( ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule();
        rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
        rule.ValidationParameters.Add("dependentname", DependentName);
        rule.ValidationParameters.Add("dependentvalue", DependentValue);
        rule.ValidationType = "requiredif";
        yield return rule;
    }
