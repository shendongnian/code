    public List<SelectListItem> AllAsSelectListItems(
            Expression<Func<T, string>> valueProperty,
            Expression<Func<T, string>> textProperty,
            string selectedValue = "")
    {
        if (valueProperty == null) throw new ArgumentNullException("valueProperty");
        if (textProperty == null) throw new ArgumentNullException("textProperty");
        if (!(valueProperty.Body is MemberExpression)) throw new ArgumentException("Must be a field or property.", "valueProperty");
        if (!(textProperty.Body is MemberExpression)) throw new ArgumentException("Must be a field or property.", "textProperty");
        var item = Expression.Parameter(typeof(T), "x");
        var valueMember = Expression.MakeMemberAccess(item, ((MemberExpression)valueProperty.Body).Member);
        var textMember = Expression.MakeMemberAccess(item, ((MemberExpression)textProperty.Body).Member);
        var targetType = typeof(SelectListItem);
        var bindings = new List<MemberBinding>
        {
            Expression.Bind(targetType.GetProperty("Value"), valueMember),
            Expression.Bind(targetType.GetProperty("Text"), textMember)
        };
        if (!string.IsNullOrEmpty(selectedValue))
            bindings.Add(Expression.Bind(targetType.GetProperty("Selected"), Expression.Equal(valueMember, Expression.Constant(selectedValue))));
        var selector = Expression.Lambda<Func<T, SelectListItem>>(
            Expression.MemberInit(Expression.New(targetType), bindings), item);
        var query = AllAsQueryable().Select(selector);
        var result = query.ToList();
        return result;
    }
