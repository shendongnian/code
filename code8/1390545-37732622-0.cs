    private static void CompareRecords<TEntity>(IQueryable<TEntity> orgs, IQueryable<TEntity> members)
    {
      var entityType = typeof (TEntity);
      var selectMethod = typeof (Queryable).GetMethods().First(x => x.Name == "Select");
      var exceptMethod = typeof(Queryable).GetMethods().First(x => x.Name == "Except");
      var toArrayMethod = typeof (Enumerable).GetMethods().First(x => x.Name == "ToArray");
      foreach (var property in entityType.GetProperties())
      {
        var paramExpr = Expression.Parameter(entityType, "x");
        var propExpr = Expression.Property(paramExpr, property.Name);
        var delegateType = typeof (Func<,>).MakeGenericType(entityType, property.PropertyType);
        var lambdaExpr = Expression.Lambda(delegateType, propExpr, paramExpr);
        var parameterizedSelectMethod = selectMethod.MakeGenericMethod(entityType, property.PropertyType);
        var parameterizedExceptMethod = exceptMethod.MakeGenericMethod(property.PropertyType);
        var source = parameterizedSelectMethod.Invoke(null, new object[] {orgs, lambdaExpr});
        var dest = parameterizedSelectMethod.Invoke(null, new object[] {members, lambdaExpr});
        var errorList = parameterizedExceptMethod.Invoke(null, new[] {source, dest});
        var errorListArray = toArrayMethod.MakeGenericMethod(property.PropertyType).Invoke(null, new[] {errorList});
        var failedTests = string.Join("\n", ((IEnumerable)errorListArray).Cast<object>().Select(x => x.ToString()));
        Assert.IsTrue(0 == failedTests.Length, $"The following {property.Name} are not contained in the source: \n{failedTests}");
      }
    }
