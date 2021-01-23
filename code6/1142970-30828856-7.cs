    private static Expression<Func<fooBarBaz, string>> GetGroupKey(string property)
        {
            var parameter = Expression.Parameter(typeof(fooBarBaz));
            var body = Expression.Property(parameter, property);
            return Expression.Lambda<Func<fooBarBaz, string>>(body, parameter);
        } 
