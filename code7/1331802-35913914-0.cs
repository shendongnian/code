    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    
    namespace Extensions
    {
        public class PredicateBuilder<T> : List<Expression<Func<T, bool>>>
        {
            private class ParameterReplacer : ExpressionVisitor
            {
                private readonly ParameterExpression _parameter;
                public ParameterReplacer(ParameterExpression parameter)
                {
                    _parameter = parameter;
                }
                protected override Expression VisitParameter(ParameterExpression node)
                {
                    return base.VisitParameter(_parameter);
                }
            }
            public Expression<Func<T, bool>> GetLambda()
            {
                if (this.Count > 0)
                {
                    var type = Expression.Parameter(typeof(T));
                    if (this.Count > 1)
                    {
                        BinaryExpression binaryExpression = Expression.MakeBinary(ExpressionType.And,
                            new ParameterReplacer(type).Visit(this.First().Body),
                            new ParameterReplacer(type).Visit(this.Skip(1).First().Body));
                        if (this.Count > 2)
                        {
                            foreach (var ex in this.ToList().Skip(2))
                                binaryExpression = Expression.And(binaryExpression, new ParameterReplacer(type).Visit(ex.Body));
                        }
                        return Expression.Lambda<Func<T, bool>>(binaryExpression, type);
                    }
                    else
                        return Expression.Lambda<Func<T, bool>>(new ParameterReplacer(type).Visit(this.First().Body), type);
                }
                return null;
            }
            public Func<T, bool> GetPredicate()
            {
    
                if (this.Count > 0)
                {
                    var type = Expression.Parameter(typeof(T));
                    if (this.Count > 1)
                    {
                        BinaryExpression binaryExpression = Expression.MakeBinary(ExpressionType.And,
                            new ParameterReplacer(type).Visit(this.First().Body),
                            new ParameterReplacer(type).Visit(this.Skip(1).First().Body));
                        if (this.Count > 2)
                        {
                            foreach (var ex in this.ToList().Skip(2))
                                binaryExpression = Expression.And(binaryExpression, new ParameterReplacer(type).Visit(ex.Body));
                        }
                        return Expression.Lambda<Func<T, bool>>(binaryExpression, type).Compile();
                    }
                    else
                        return Expression.Lambda<Func<T, bool>>(new ParameterReplacer(type).Visit(this.First().Body), type).Compile();
                }
                return null;
            }
        }
    }
