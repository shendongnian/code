    public bool IsAnyMemberNull<TEntity, TMember>(Expression<Func<TEntity, TMember>> paramChain, TEntity entityDb)
    {
        var expressionsToCheck = new List<MemberExpression>();
        var expression = paramChain.Body as MemberExpression;
        while (expression != null)
        {
            expressionsToCheck.Add(expression);
            expression = expression.Expression as MemberExpression;
        }
        object value = entityDb;
        for (var i = expressionsToCheck.Count - 1; i >= 0; i--)
        {
            var member = expressionsToCheck[i].Member;
            if (member is PropertyInfo) value = (member as PropertyInfo).GetValue(value);
            else if (member is FieldInfo) value = (member as FieldInfo).GetValue(value);
            else throw new Exception(); // member generally should be a property or field, shouldn't it?
            if (value == null)
                return true;
        }
        return false;
    }
