    using System;
    using System.Linq.Expressions;
    public static class PredicateMapper
    {
        public static Expression<Func<TTo, bool>> Map<TFrom, TTo>(
            this Expression<Func<TFrom, bool>> predicate)
        {
            var parameter = Expression.Parameter(typeof(TTo));
            var body = new ParameterReplacer(parameter).Visit(predicate.Body);
            return Expression.Lambda<Func<TTo, bool>>(body, parameter);
        }
        private class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression parameter;
            public ParameterReplacer(ParameterExpression parameter)
            {
                this.parameter = parameter;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return this.parameter;
            }
        }
    }
