        private static Expression<Func<T, bool>> BuildContainsPredicate<T>(string propertyName, string propertyValue)
        {
            PropertyInfo propertyInfo = typeof (T).GetProperty(propertyName);
            // ListOfProducts.Where(p => p.Contains(propertyValue))
            ParameterExpression pe = Expression.Parameter(typeof(T), "p");
            MemberExpression memberExpression = Expression.MakeMemberAccess(pe, propertyInfo);
            // Thanks to Servy's suggestion
            Expression toLowerExpression = Expression.Call(memberExpression, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            MethodInfo methodInfo = typeof (string).GetMethod("Contains", new Type[] {typeof (string)});
            ConstantExpression constantExpression = Expression.Constant(propertyValue, typeof(string));
            // Predicate Body - p.Name.Contains("Saw")
            Expression call = Expression.Call(toLowerExpression, methodInfo, constantExpression);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, pe);
            return lambda;
        }
