            public static Expression GetExpression(Expression parameter, object Operator, object value, params string[] properties)
            {
                Expression resultExpression = null;
                Expression childParameter, navigationPropertyPredicate;
                Type childType = null;
                if (properties.Count() > 1)
                {
                    parameter = Expression.Property(parameter, properties[0]);
                    var isCollection = typeof(IEnumerable).IsAssignableFrom(parameter.Type);
                    if (isCollection)
                    {
                        childType = parameter.Type.GetGenericArguments()[0];
                        childParameter = Expression.Parameter(childType, childType.Name);
                    }
                    else
                    {
                        childParameter = parameter;
                    }
                    var innerProperties = properties.Skip(1).ToArray();
                    navigationPropertyPredicate = GetExpression(childParameter, Operator, value, innerProperties);
                    if (isCollection)
                    {
                        var anyMethod = typeof(Enumerable).GetMethods().Single(m => m.Name == "Any" && m.GetParameters().Length == 2);
                        anyMethod = anyMethod.MakeGenericMethod(childType);
                        navigationPropertyPredicate = Expression.Call(anyMethod, parameter, navigationPropertyPredicate);
                        resultExpression = BuildLambda(parameter, navigationPropertyPredicate);
                    }
                    else
                    {
                        resultExpression = navigationPropertyPredicate;
                    }
                }
                else
                {
                    ConstantExpression right = null;
                    var childProperty = parameter.Type.GetProperty(properties[0]);
                    var left = Expression.Property(parameter, childProperty);
                    right = (value != null) ? right = Expression.Constant(value, value.GetType()) : Expression.Constant(string.Empty);
                    navigationPropertyPredicate = GetExpression(left, right, Operator);
                    resultExpression = BuildLambda(parameter, navigationPropertyPredicate);
                }
                return resultExpression;
            }
           private static Expression GetExpression(MemberExpression left, ConstantExpression right, Object p)
            {
                MethodInfo c = null;
                if (p is OperatorUsedWithString)
                {
                    switch ((OperatorUsedWithString)p)
                    {
                        case OperatorUsedWithString.CommencePar:
                            c = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                            return Expression.Call(left, c, right);
                        case OperatorUsedWithString.Contient:
                            c = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                            return Expression.Call(left, c, right);
                        case OperatorUsedWithString.TerminePar:
                            c = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
                            return Expression.Call(left, c, right);
                        case OperatorUsedWithString.Egal:
                            c = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
                            return Expression.Call(left, c, right);
                    }
                }
                if (p is OperatorUsedWithNumber)
                {
                    switch ((OperatorUsedWithNumber)p)
                    {
                        case OperatorUsedWithNumber.Egal:
                            return Expression.Equal(left, right);
                        case OperatorUsedWithNumber.Inferieur:
                            return Expression.LessThan(left, right);
                        case OperatorUsedWithNumber.InferieurEgal:
                            return Expression.LessThanOrEqual(left, right);
                        case OperatorUsedWithNumber.Superieur:
                            return Expression.GreaterThan(left, right);
                        case OperatorUsedWithNumber.SuperieurEgal:
                            return Expression.GreaterThanOrEqual(left, right);
                    }
                }
                if (p is OperatorUsedWithDateTime)
                {
                    switch ((OperatorUsedWithDateTime)p)
                    {
                        case OperatorUsedWithDateTime.PasPresent:
                            return Expression.Equal(left, Expression.Constant(null));
                        case OperatorUsedWithDateTime.Present:
                            return Expression.NotEqual(left, Expression.Constant(null));
                    }
                }
                throw new NotImplementedException();
            }
        }
