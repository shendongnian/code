    public static EntityTypeConfiguration<T> IgnoreAllBut<T>(this EntityTypeConfiguration<T> entityTypeConfiguration,
            params Expression<Func<T, object>>[] properties) where T : class
    {
        // Extract the names from the expressions
        var namesToKeep = properties.Select(a =>
        {
            var member = a.Body as MemberExpression;
            // If the property is a value type, there will be an extra "Convert()"
            // This will get rid of it.
            if (member == null)
            {
                var convert = a.Body as UnaryExpression;
                if (convert == null) throw new ArgumentException("Invalid expression");
                member = convert.Operand as MemberExpression;
            }
            if (member == null) throw new ArgumentException("Invalid expression");
            return (member.Member as PropertyInfo).Name;
        });
        // Now we loop over all properties, excluding the ones we want to keep
        foreach (var property in typeof(T).GetProperties().Where(p => !namesToKeep.Contains(p.Name)))
        {
            // Here is the tricky part: we need to build an expression tree
            // to pass to Ignore()
            // first, the parameter
            var param = Expression.Parameter(typeof (T), "e");
            // then the property access
            Expression expression = Expression.Property(param, property);
            // If the property is a value type, we need an explicit Convert() operation
            if (property.PropertyType.IsValueType)
            {
                expression = Expression.Convert(expression, typeof (object));
            }
            // last step, assembling everything inside a lambda that
            // can be passed to Ignore()
            var result = Expression.Lambda<Func<T, object>>(expression, param);
            entityTypeConfiguration.Ignore(result);
        }
        return entityTypeConfiguration;
    }
