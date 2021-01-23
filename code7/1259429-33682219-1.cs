    public static object GetContainer<T>(Expression<Func<T>> propertyLambdaExpression)
    {
        return Evaluate((propertyLambdaExpression.Body as MemberExpression).Expression);
    }
    public static object Evaluate(Expression e)
    {
        switch (e.NodeType)
        {
            case ExpressionType.Constant:
                return (e as ConstantExpression).Value;
            case ExpressionType.MemberAccess:
                {
                    var propertyExpression = e as MemberExpression;
                    var field = propertyExpression.Member as FieldInfo;
                    var property = propertyExpression.Member as PropertyInfo;
                    var container = propertyExpression.Expression == null ? null : Evaluate(propertyExpression.Expression);
                    if (field != null)
                        return field.GetValue(container);
                    else if (property != null)
                        return property.GetValue(container, null);
                    else
                        return null;
                }
            case ExpressionType.ArrayIndex: //Arrays
            {
                var arrayIndex = e as BinaryExpression;
                var idx = (int)Evaluate(arrayIndex.Right);
                var array = (object[])Evaluate(arrayIndex.Left);
                return array[idx];
            }
            case ExpressionType.Call: //Generic Lists and Dictionaries
            {
                var call = e as MethodCallExpression;
                var callingObj = Evaluate(call.Object);
                object[] args = new object[call.Arguments.Count];
                for (var idx = 0; idx < call.Arguments.Count; ++idx)
                    args[idx] = Evaluate(call.Arguments[idx]);
                return call.Method.Invoke(callingObj, args);
            }
            default:
                return null;
        }
    }
