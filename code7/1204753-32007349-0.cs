    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    // A simple expression visitor to replace some nodes of an expression 
    // with some other nodes. Can be used with anything, not only with
    // ParameterExpression
    public class SimpleExpressionReplacer : ExpressionVisitor
    {
        public readonly Dictionary<Expression, Expression> Replaces;
    
        public SimpleExpressionReplacer(Expression from, Expression to)
        {
            Replaces = new Dictionary<Expression, Expression> { { from, to } };
        }
    
        public SimpleExpressionReplacer(Dictionary<Expression, Expression> replaces)
        {
            // Note that we should really clone from and to... But we will
            // ignore this!
            Replaces = replaces;
        }
    
        public SimpleExpressionReplacer(IEnumerable<Expression> from, IEnumerable<Expression> to)
        {
            Replaces = new Dictionary<Expression, Expression>();
    
            using (var enu1 = from.GetEnumerator())
            using (var enu2 = to.GetEnumerator())
            {
                while (true)
                {
                    bool res1 = enu1.MoveNext();
                    bool res2 = enu2.MoveNext();
    
                    if (!res1 || !res2)
                    {
                        if (!res1 && !res2)
                        {
                            break;
                        }
    
                        if (!res1)
                        {
                            throw new ArgumentException("from shorter");
                        }
    
                        throw new ArgumentException("to shorter");
                    }
    
                    Replaces.Add(enu1.Current, enu2.Current);
                }
            }
        }
    
        public override Expression Visit(Expression node)
        {
            Expression to;
    
            if (node != null && Replaces.TryGetValue(node, out to))
            {
                return base.Visit(to);
            }
    
            return base.Visit(node);
        }
    }
