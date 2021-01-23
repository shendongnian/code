    public List<SelectListItem> AllAsSelectListItemsSpecifyProperties(Expression<Func<T, string>> valueProperty, Expression<Func<T, string>> textProperty, string selectedValue = "")
    {
        return AllAsQueryable().Select(i => new SelectListItem()
        {
            Value = GetValue(valueProperty.Body as MemberExpression).ToString(),
            Text = GetValue(textProperty.Body as MemberExpression).ToString(),
            Selected = (selectedValue == valueProperty)
        })
        .ToList();
    }
    
    
    private object GetValue(MemberExpression member)
    {
        var objectMember = Expression.Convert(member, typeof(object));
    
        var getterLambda = Expression.Lambda<Func<object>>(objectMember);
    
        var getter = getterLambda.Compile();
    
        return getter();
    }
