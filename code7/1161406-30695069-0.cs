    ParameterExpression param = Expression.Parameter(typeof(Entities.Area), "x");
    Expression body = Expression.AndAlso(where.Body, whereAdd.Body);
    var newWhere = Expression.Lambda<Func<Entities.Area, bool>>(body, param);
    Console.WriteLine(newWhere.ToString());
    // x => (((x.Created > Convert(value(UserQuery).Value)) OrElse ((x.Changed != null) AndAlso (x.Changed > Convert(value(UserQuery).Value)))) AndAlso (x.Client.Id == ClientInfo.CurrentClient.Id))
