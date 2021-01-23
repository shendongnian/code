    public class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> x = (i => i > 3 && i % 4 == 0);
            var visitor = new GetSubExpressionVisitor(4);
            visitor.Visit(x);
        }
    }
    public class GetSubExpressionVisitor : ExpressionVisitor
    {
        private List<ParameterExpression> _parameters = new List<ParameterExpression>();
        private readonly object[] _parameterValues;
        public GetSubExpressionVisitor(params object[] parameterValues )
        {
            _parameterValues = parameterValues;
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _parameters.AddRange(node.Parameters);
            return base.VisitLambda(node);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                //Add more binary types here if you like. Add Modulo to see the result of i % 4
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
                    Log(node);
                    break;
            }
            return base.VisitBinary(node);
        }
        private void Log(BinaryExpression node)
        {
            var subLambda = Expression.Lambda(
                Expression.Convert(node, typeof (object)),
                _parameters
            );
            var subFunc = subLambda.Compile();
            var result = subFunc.DynamicInvoke(_parameterValues);
            //node is the subexpression, result is the result. Do whatever you want with it here.
        }
    }
