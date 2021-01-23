    // Some form.
    SetFieldReadOnly( () => Entity.UserName );
    ...
    // Base form.
    private void SetFieldReadOnly(Expression<Func<object>> property)
    {
        var propName = GetPropNameFromExpr(property);
        SetFieldsReadOnly(propName);
    }
    private void SetFieldReadOnly(string propertyName)
    {
        ...
    }
