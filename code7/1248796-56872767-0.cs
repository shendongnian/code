    public Expression<Func<T, object>> CreateMemberLambda<T>(string parameterName)
        {
            var type = typeof(T);
            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField;
            var parameter = type.GetField(parameterName, bindFlags);
            var classExpression = Expression.Parameter(type, type.Name);
            var memberAccessExpression = Expression.MakeMemberAccess(classExpression, parameter);
            var lambda = Expression.Lambda<Func<T, object>>(memberAccessExpression, classExpression);
            return lambda;
        }
