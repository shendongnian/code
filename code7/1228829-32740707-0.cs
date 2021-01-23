    public Func<T, object> GetLambda<T>(string property)
        {
            var param = Expression.Parameter(typeof(T), "p");
            Expression parent = Expression.Property(param, property);
            if (!parent.Type.IsValueType)
            {
                return Expression.Lambda<Func<T, object>>(parent, param).Compile();
            }
            var convert = Expression.Convert(parent, typeof(object));
            return Expression.Lambda<Func<T, object>>(convert, param).Compile();
        }
