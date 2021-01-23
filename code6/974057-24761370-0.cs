    //dirty way
    var rule = new ModelClientValidationRule
    {
    	ValidationType = "dynamicrange",
    	ErrorMessage = this.ErrorMessage,
    };
    string Prefix = ((System.Web.Mvc.ViewContext)(context)).ViewData.TemplateInfo.HtmlFieldPrefix;
    Prefix = Prefix.Replace(metadata.PropertyName, "");
    System.Text.RegularExpressions.Regex Regex = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 -]");
    Prefix = Regex.Replace(Prefix, "_");
    rule.ValidationParameters["minvalueproperty"] = Prefix + _minPropertyName;
    rule.ValidationParameters["maxvalueproperty"] = Prefix + _maxPropertyName;
    yield return rule;
