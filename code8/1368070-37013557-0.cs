        public static Expression<Func<T, Tout>> PropertySelector<T, Tout>(this IEnumerable<T> collection, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException(nameof(propertyName));
            }
            var properties = typeof(T).GetProperties();
            if (!properties.Any(p => p.Name == propertyName))
            {
                throw new ObjectNotFoundException($"Property: {propertyName} not found for type [{typeof(T).Name}]");
            }
            var propertyInfo = properties.Single(p => p.Name == propertyName);
            var alias = Expression.Parameter(typeof(T), "_");
            var property = Expression.Property(alias, propertyInfo);
            var funcType = typeof(Func<,>).MakeGenericType(typeof(T), propertyInfo.PropertyType);
            var lambda = Expression.Lambda(funcType, property, alias);
            return (Expression<Func<T, Tout>>)lambda;
        }
