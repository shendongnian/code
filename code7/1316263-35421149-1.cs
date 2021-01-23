        /// <summary>
        /// Generates the Lambda "TIn => TIn.memberName [comparison] value"
        /// </summary>
        static Expression<Func<TIn, bool>> MakeSimplePredicate<TIn>(string memberName, ExpressionType comparison, object value)
        {
            var parameter = Expression.Parameter(typeof(TIn), "t");
            Expression left = Expression.PropertyOrField(parameter, memberName);
            return (Expression<Func<TIn, bool>>)Expression.Lambda(Expression.MakeBinary(comparison, left, Expression.Constant(value)), parameter);
        }
