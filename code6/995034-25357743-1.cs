       public static IQueryable<T1> Apply<T1, TField>(IQueryable<T1> query, Expression<Func<T1, TField>> field, TField value, Comparison compare)
        {
            ExpressionType expressionType;
            ConstantExpression searchValue = Expression.Constant(value);
            ParameterExpression parameter = field.Parameters.First();
            Expression body;
            if (!Enum.TryParse(Enum.GetName(typeof(Comparison),compare), true, out expressionType)) 
            {
                //probably string: StartsWith, EndsWith, Contains
                MethodInfo stringMethod = GetStringMethodInfo(compare);
                body = Expression.Call(field.Body, stringMethod, searchValue);
            }
            else
            {
                body = Expression.MakeBinary(expressionType, field, searchValue);
            }
            Expression<Func<T1, bool>> predicate = Expression.Lambda<Func<T1, bool>>(body, parameter);
            return query.Where(predicate);
        }
        private static MethodInfo GetStringMethodInfo(Comparison comparer)
        {
            string methodName = Enum.GetName(typeof(Comparison), comparer);
            return
                typeof(string).GetMethods()
                    .FirstOrDefault(m => m.Name.Equals(methodName) && m.GetParameters().Count() == 1);
        }
        public enum Comparison
        {
            GreaterThan = ExpressionType.GreaterThan,
            GreaterThanOrEqual = ExpressionType.GreaterThanOrEqual,
            LessThan = ExpressionType.LessThan,
            LessThanOrEqual = ExpressionType.LessThanOrEqual,
            Equals = ExpressionType.Equal,
            NotEqual = ExpressionType.NotEqual,
            StartsWith,
            EndsWith,
            Contains
        }
