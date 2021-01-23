        public static Func<PPart, IComparable> GetOrderByPropertyExpression(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof (PPart));
            PropertyInfo baseProperty = typeof (PPart).GetProperty(propertyName);
            Expression memberExpression = Expression.Property(parameter, baseProperty);
            return
                Expression.Lambda<Func<PPart, IComparable>>(Expression.TypeAs(memberExpression, typeof (IComparable)),
                                                            parameter).Compile();
        }
