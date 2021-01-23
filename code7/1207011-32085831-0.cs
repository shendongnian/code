    var targetExp = Expression.Parameter(typeof(Citizen), "rootobject");
    var valueExp = Expression.Constant("\"StrozeR\"");
    var valueExp2 = Expression.Constant(1765116);
    var fieldExp = Expression.Property(targetExp, "name");
    var fieldExp2 = Expression.Property(targetExp, "id");
    var assignExp = Expression.Equal(fieldExp, valueExp);
    var assignExp2 = Expression.Equal(fieldExp2, valueExp2);
    var predicateBody1 = Expression.AndAlso(assignExp, assignExp2);
    var queryableType = typeof(System.Linq.Queryable);
    var whereMethod = queryableType.GetMethods()
           .First(m =>
           {
               var parameters = m.GetParameters().ToList();
               //Put more restriction here to ensure selecting the right overload                
               //overload that has 2 parameters, and second parameter has 2 generic types
               return m.Name == "Where" && m.IsGenericMethodDefinition &&
                     parameters.Count == 2;
           });
    var whereClause = Expression.Lambda<Func<Citizen, bool>>(predicateBody1, 
                      new ParameterExpression[] { targetExp });
    var genericMethod = whereMethod.MakeGenericMethod(typeof(Citizen));
    var newQuery = (IQueryable<Citizen>)genericMethod
                  .Invoke(genericMethod, new object[] { queryableDataaa, whereClause });
