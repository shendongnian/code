    public static Expression<Func<Airplane, bool>> StatusFilter(string sought)
    {
      var param = Expression.Parameter(typeof(Airplane), "p");                      // p
      var property = typeof(Airplane).GetProperty("Status");                        // .Status
      var propExp = Expression.Property(param, property);                           // p.Status
      var soughtExp = Expression.Constant(sought);                                  // sought
      var contains = typeof(string).GetMethod("Contains", new[]{ typeof(string) }); // .Contains(string)
      var callExp = Expression.Call(propExp, contains, soughtExp);                  // p.Status.Contains(sought)
      var lambda = Expression.Lambda<Func<Airplane, bool>>(callExp, param);         // p => p.Status.Contains(sought);
      return lambda;
    }
