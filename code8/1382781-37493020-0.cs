    private PrimitivePropertyConfiguration GetStructPropertyConfiguration(DbModelBuilder mb, Type entityType, string propertyName, Type propertyType)
    {
      var structuralConfiguration = typeof(DbModelBuilder).GetMethod("Entity")
            .MakeGenericMethod(entityType).Invoke(mb, null);
      var param = System.Linq.Expressions.Expression.Parameter(entityType);
      var funcType = typeof(Func<,>).MakeGenericType(entityType, propertyType);
      var expressionType = typeof(System.Linq.Expressions.Expression);
      var lambdaMethod = expressionType.GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(mi => mi.Name == "Lambda").FirstOrDefault();
      var genericLambdaMethod = lambdaMethod.MakeGenericMethod(funcType);
      var prop = System.Linq.Expressions.Expression.Property(param, propertyName);
      var inv = genericLambdaMethod.Invoke(null, new object[] { prop, new[] { param } });
      var propertyMethod = this.GetType().GetMethods(BindingFlags.Public|BindingFlags.Instance)
            .Where(mi => mi.Name == "Property").FirstOrDefault();
      var propertyMethodGeneric = propertyMethod.MakeGenericMethod(propertyType);
      var mapping = propertyMethodGeneric.Invoke(structuralConfiguration , new[]{inv}) 
            as PrimitivePropertyConfiguration;
      return mapping;
    }
