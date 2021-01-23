    string field = "tableID";
    ParameterExpression param = Expression.Parameter(typeof(Table), "x");
    MemberExpression propExpression = Expression.PropertyOrField(param, field);
    Expression<Func<Table, string>> selector = Expression.Lambda<Func<Table, string>>(propExpression, param);
    var result = db.Table.Select(selector).First();
