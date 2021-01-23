    ParameterExpression param = Expression.Parameter(typeof(Employee), "item");
    MemberExpression address = Expression.Property(param, "Address");
    BinaryExpression indexedAddress = Expression.ArrayIndex(address, Expression.Constant(1));
    MemberExpression city = Expression.Property(indexedAddress, "City"); // Assuming "City" is a string.
    // This will give us: item => item.Address[1].City
    Expression<Func<Employee, string>> memberAccessLambda = Expression.Lambda<Func<Employee, string>>(city, param);
