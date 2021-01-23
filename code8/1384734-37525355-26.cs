    using System;
    using System.Linq.Expressions;
    public static class PredicateMapper
    {
        public static Expression<Func<TTo, bool>> CastParameter<TFrom, TTo>(
            this Expression<Func<TFrom, bool>> predicate)
        {
            var parameter = Expression.Parameter(typeof(TTo));
            var body = new ParameterReplacer<TTo>(parameter).Visit(predicate.Body);
            return Expression.Lambda<Func<TTo, bool>>(body, parameter);
        }
        private class ParameterReplacer<TTo> : ExpressionVisitor
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
            protected override Expression VisitMember(MemberExpression node)
            {
                var matchingMember = typeof(TTo).GetProperty(node.Member.Name);
                return Expression.Property(this.Visit(node.Expression), matchingMember);
            }
        }
    }
