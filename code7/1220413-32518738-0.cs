    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string property, bool descending)
        {
            if(!descending)
                return ApplyOrder<T>(source, property, "OrderBy");
            else
                return ApplyOrder<T>(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }
        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
        public static bool TryParseSortText(this string sortExpression, out string property, out bool descending)
        {
            descending = false;
            property = string.Empty;
            if (string.IsNullOrEmpty(sortExpression))
                return false;
            string[] parts = sortExpression.Split(' ');
            if (parts.Length > 0 && !string.IsNullOrEmpty(parts[0]))
            {
                property = parts[0];
                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }
            }
            else
                return false;
            return true;
        }
