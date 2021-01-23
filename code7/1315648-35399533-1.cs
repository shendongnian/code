    public IEnumerable<SalesRegister> GetSalesRegister(string sortBy)
    {
        var param = Expression.Parameter(typeof (SalesRegister), "x");
        var prop = typeof (SalesRegister).GetProperty(sortBy);
        var objectFuncType = typeof (Func<,>).MakeGenericType(typeof (SalesRegister), prop.PropertyType);
        var propExp = Expression.PropertyOrField(param, sortBy);
        var exp = Expression.Lambda(objectFuncType, propExp, param);
        var converted = Expression.Convert(exp.Body, typeof (object)); // only needed if you are passing in no referene types like int, double, etc as parameters, otherwise ignore this line and use 'exp' in place of 'converted' in the next line
        var sortByExp= Expression.Lambda<Func<SalesRegister, object>>(converted, exp.Parameters);
        return _client.GetAllSalesRegisters().OrderBy(sortByExp);
    }
