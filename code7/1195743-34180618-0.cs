    public HtmlInputButton InputButton(string attributeName, string attributeValue, UITestControl container = null)
    {
        string controlDefinition = string.Format("{0}=\"{1}\"", attributeName, attributeValue);
        HtmlInputButton button = new HtmlInputButton(container ?? document);
        button.SearchProperties.Add(new PropertyExpression(HtmlControl.PropertyNames.ControlDefinition, controlDefinition, PropertyExpressionOperator.Contains));
        return button;
    }
