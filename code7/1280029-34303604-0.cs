    public List<SelectListItem> AllAsSelectListItemsSpecifyProperties(Expression<Func<T, string>> valueProperty, Expression<Func<T, string>> textProperty, string selectedValue = "")
    {
        return AllAsQueryable().Select(i => new SelectListItem()
        {
            Value = GetPropertyName(valueProperty),
            Text = GetPropertyName(textProperty),
            Selected = (selectedValue == valueProperty)
        })
        .ToList();
    }
    private string GetPropertyName(Expression<Func<T, string>> expression)
    {
        var memberExpression = expression.Body as MemberExpression;
        var propertyInfo = memberExpression.Member as PropertyInfo;
        return propertyInfo.Name;
    }
