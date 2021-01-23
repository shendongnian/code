        private Expression<Func<T, bool>> GetSearchExpression<T>(
            string targetField, ExpressionType comparison, object value)
        {
            //get the property or field of the target object (ResultType)
            //which will contain the value to be checked
            var param = Expression.Parameter(ResultType, "t");
            Expression left = null;
            foreach (var part in DeQualifyFieldName(targetField, ResultType))
                left = Expression.PropertyOrField(left == null ? param : left, part);
            //Get the value against which the property/field will be compared
            var right = Expression.Constant(value);
            //join the expressions with the specified operator
            var binaryExpression = Expression.MakeBinary(comparison, left, right);
            return Expression.Lambda<Func<T, bool>>(binaryExpression, param);
        }
