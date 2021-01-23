        public static Func<TObject, TProperty> GetPropGetter<TObject, TProperty>(string propertyName)
        {
            ParameterExpression paramExpression = Expression.Parameter(typeof(TObject), "value");
            Expression propertyGetterExpression = Expression.Property(paramExpression, propertyName);
            Func<TObject, TProperty> result =
                Expression.Lambda<Func<TObject, TProperty>>(propertyGetterExpression, paramExpression).Compile();
            return result;
        }
