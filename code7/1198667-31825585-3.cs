    public static class EntityTypeConfigurationExtentions
    {
        public static EntityTypeConfiguration<TEntityType> IgnoreAllExcept<TEntityType>(this EntityTypeConfiguration<TEntityType> t, params string[] except)
            where TEntityType:class
        {
            var type = typeof(TEntityType);
            var properties = type.GetProperties();
            var dontIgnore = except ?? new string[0];
            //Here you can add more constraints on the class properties
            var toIgnore = properties.Where(x => !except.Contains(x.Name) && 
                                                 x.SetMethod != null).ToList();
            foreach (var name in toIgnore)
            {
                var selector = GetIgnoreExpression<TEntityType>(name);
                MethodInfo genericMethod = GetIgnoreMethod<TEntityType>(name.PropertyType);
                genericMethod.Invoke(t, new object[] { selector });
            }
            return t;
        }
        private static MethodInfo GetIgnoreMethod<TEntityType>(Type propType)
        {
            var t = typeof(EntityTypeConfiguration<>);
            t = t.MakeGenericType(typeof(TEntityType));
            MethodInfo method = t.GetMethod("Ignore");
            MethodInfo genericMethod = method.MakeGenericMethod(propType);
            return genericMethod;
        }
        
        //This method creates the 'x=>x.PropertyName' expression for Ignore method
        private static Expression GetIgnoreExpression<TEntityType>(PropertyInfo prop)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TEntityType), "x");
            MemberExpression property = Expression.Property(arg, prop.Name);
            var exp = Expression.Lambda(property, new ParameterExpression[] { arg });
            return exp;
        }
    }
