    public class ExpressionUtils
    {
        public static MethodCallExpression ConvertToType(
            ParameterExpression sourceParameter,
            PropertyInfo sourceProperty,
            TypeCode typeCode)
        {
            var sourceExpressionProperty = Expression.Property(sourceParameter, sourceProperty);
            var changeTypeMethod = typeof(Convert).GetMethod("ChangeType", new Type[] { typeof(object), typeof(TypeCode) });
            var callExpressionReturningObject = Expression.Call(changeTypeMethod, sourceExpressionProperty, Expression.Constant(typeCode));
            return callExpressionReturningObject;
        }
    }
