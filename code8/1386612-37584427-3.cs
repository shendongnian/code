    Public Expression<Func<TEntity, bool>> SrchExpression(string nameofFieldToSearch, string searchString)
    {
      var parameterType = Expression.Parameter(typeof(TEntity), "obj");
      var memberExpression = Expression.Property(typeof(string), nameofFieldToSearch)
     // Calls Extension method created underneath
     var filtersMethodInfo = typeof(StringExtensions).GetMethod("Contains", new[] { typeof(string), typeof(string) });
     var filtersConstantExpression = Expression.Constant(searchString, typeof(string));
     var finalExpression = Expression.Call(null, filtersMethodInfo, memberExpression, filtersConstantExpression)
     return Expression.Lambda<Func<TEntity, bool>>(finalExpression, parameterType)
    }
