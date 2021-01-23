    public class MyVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.Name == "ActiveRecords")
            {
                var entityType = m.Method.GetGenericArguments()[0];
                var whereMethod = genericWhereMethod.MakeGenericMethod(entityType);
                var param = Expression.Parameter(entityType);
                var expressionToPassToWhere =
                    Expression.NotEqual(
                        Expression.Property(param, "RecordStatusTypeId"),
                        Expression.Constant((int)RecordStatusTypes.Deleted));
                Expression newExpression =
                    Expression.Call(
                        whereMethod,
                        m.Arguments[0],
                        Expression.Lambda(
                            typeof(Func<,>).MakeGenericType(entityType, typeof(bool)),
                            expressionToPassToWhere,
                            param));
                return newExpression;
            }
            return base.VisitMethodCall(m);
        }
    
        //This is reference to the open version of `Enumerable.Where`
        private static MethodInfo genericWhereMethod;
        static MyVisitor()
        {
            genericWhereMethod = typeof (Enumerable).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.Name == "Where" && x.GetGenericArguments().Length == 1)
                .Select(x => new {Method = x, Parameters = x.GetParameters()})
                .Where(x => x.Parameters.Length == 2 &&
                            x.Parameters[0].ParameterType.IsGenericType &&
                            x.Parameters[0].ParameterType.GetGenericTypeDefinition() == typeof (IEnumerable<>) &&
                            x.Parameters[1].ParameterType.IsGenericType &&
                            x.Parameters[1].ParameterType.GetGenericTypeDefinition() == typeof (Func<,>))
                .Select(x => x.Method)
                .Single();
        }
    }
