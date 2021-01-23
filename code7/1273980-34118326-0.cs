    ParameterExpression param = Expression.Parameter(typeof(Employee), "item");
    MemberExpression address = Expression.Property(param, "Address");
    BinaryExpression indexedAddress = Expression.ArrayIndex(address, Expression.Constant(1));
    MemberExpression city = Expression.Property(indexedAddress, "City");
    Expression<Func<Employee, City>> lambda = Expression.Lambda<Func<Employee, City>>(city, param);
