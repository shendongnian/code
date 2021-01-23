    public PropertyExpression GetByTaskId(string value) 
    {
      return new PropertyExpression(
        HtmlControl.PropertyNames.ControlDefinition, 
        $"data-task-id=\"{value}\"", 
        PropertyExpressionOperator.Contains
      );
    }
    HtmlInputButton button = new HtmlInputButton(document);
    button.SearchProperties.Add(GetByTaskId("123"));
