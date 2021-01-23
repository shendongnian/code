    public class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> x = (i => i > 3 && i % 4 == 0);
            var visitor = new GetSubExpressionVisitor();
            visitor.Visit(x);
            var visited = (Expression<Func<int, bool>>)visitor.Visit(x);
            var func = visited.Compile();
            var result = func(4);
        }
    }
    public class GetSubExpressionVisitor : ExpressionVisitor
    {
        private readonly List<ParameterExpression> _parameters = new List<ParameterExpression>();
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _parameters.AddRange(node.Parameters);
            return base.VisitLambda(node);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Modulo:
                case ExpressionType.Equal:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return WithLog(node);
            }
            return base.VisitBinary(node);
        }
        public Expression WithLog(BinaryExpression exp)
        {
            return Expression.Block(
                Expression.Call(
                    typeof(Debug).GetMethod("Print", new Type[] { typeof(string) }),
                    new[] 
                    { 
                        Expression.Call(
                            typeof(string).GetMethod("Format", new [] { typeof(string), typeof(object), typeof(object)}),
                            Expression.Constant("Executing Rule: {0} --> {1}"),
                            Expression.Call(Expression.Constant(exp), exp.GetType().GetMethod("ToString")),
                            Expression.Convert(
                                exp,
                                typeof(object)
                            )
                        )
                    }
                ),
                base.VisitBinary(exp)
            );
        }
    }
