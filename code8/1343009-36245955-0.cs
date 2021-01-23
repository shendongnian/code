    var parameterExp = Expression.Parameter(typeof(Product), "type");
    var propertyExp = Expression.Property(parameterExp, propertyName);
    MethodInfo method = typeof(Enumerable).GetMethods()
                               .Where(m => m.Name == "Contains")
                               .Single(m => m.GetParameters().Length == 2)
                               .MakeGenericMethod(typeof(Product));
    var someValue = Expression.Constant(propertyValue, typeof(string));
    var containsMethodExp = Expression.Call(propertyExp, method, someValue);
    Expression<Func<Product, bool>> predicate = Expression.Lambda<Func<T, bool>>
                 (containsMethodExp, parameterExp);
    
    var query = query.Where(predicate);
