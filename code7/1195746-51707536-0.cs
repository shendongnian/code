    public PropertyExpression GetByCustomAttribute(string attributeName, string value)
    {
        return new PropertyExpression(HtmlControl.PropertyNames.ControlDefinition,
                                      $"{attributeName}=\"{value}\"",
                                      PropertyExpressionOperator.Contains);
    }
    public static T GetControlByCustomAttribute<T>(this BrowserWindow browserWindow,
                                                   string attributeName,
                                                   string value,
                                                   HtmlControl context = null)
         where T : HtmlControl
    {
        string queryContext = (context != null ? "arguments[0]" : "document");
        string script = $"return {queryContext}.querySelector(\"[{attributeName}=\'{value}\']\");";
        return browserWindow.ExecuteScript(script, context) as T;
    }
