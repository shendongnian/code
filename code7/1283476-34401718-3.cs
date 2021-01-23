    public List<SelectListItem> AllAsSelectListItems(
            Expression<Func<T, string>> valueSelector,
            Expression<Func<T, string>> textProperty,
            string selectedValue = "")
    {
        if (valueSelector == null) throw new ArgumentNullException("valueSelector");
        if (textProperty == null) throw new ArgumentNullException("textProperty");
        if (!(textProperty.Body is MemberExpression)) throw new ArgumentException("Must be a field or property.", "textProperty");
        var item = valueSelector.Parameters[0];
        var itemValue = valueSelector.Body;
        var itemText = Expression.MakeMemberAccess(item, ((MemberExpression)textProperty.Body).Member);
        var targetType = typeof(SelectListItem);
        var bindings = new List<MemberBinding>
        {
            Expression.Bind(targetType.GetProperty("Value"), itemValue),
            Expression.Bind(targetType.GetProperty("Text"), itemText)
        };
        if (!string.IsNullOrEmpty(selectedValue))
            bindings.Add(Expression.Bind(targetType.GetProperty("Selected"), Expression.Equal(itemValue, Expression.Constant(selectedValue))));
        var selector = Expression.Lambda<Func<T, SelectListItem>>(Expression.MemberInit(Expression.New(targetType), bindings), item);
        var query = AllAsQueryable().Select(selector);
        var result = query.ToList();
        return result;
    }
