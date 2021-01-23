    class Program
    {
        static void Main(string[] args) {
            Expression<Func<double, bool>> predicate = x => x > 3 && x > 4;
            var visitor = new BinaryExpressionVisitor();
            predicate = (Expression<Func<double, bool>>)visitor.Visit(predicate);
        }
    }
    public class BinaryExpressionVisitor : ExpressionVisitor
    {
        private bool root = true;
        private List<ConstantExpression> constants = new List<ConstantExpression>();
        private List<BinaryExpression> binaryExpressions = new List<BinaryExpression>();
        private HashSet<ParameterExpression> @params = new HashSet<ParameterExpression>();
        protected override Expression VisitBinary(BinaryExpression node) {
            if (IsSimpleBinaryExpression(node)) {
                binaryExpressions.Add(node);
            }
            else if (node.NodeType != ExpressionType.AndAlso) {
                return node;
            }
            if (root) {
                root = false;
                Visit(node.Right);
                Visit(node.Left);
                if (@params.Count == 1) {
                    var @param = @params.ElementAt(0);
                    var hashSet = new HashSet<ExpressionType>(binaryExpressions.Select(be => be.NodeType));
                    if (hashSet.Count == 1) {
                        var binaryExpression = binaryExpressions[0];
                        var nodeType = binaryExpression.NodeType;
                        var constant = GetConstantByNodeType(nodeType);
                        return Expression.MakeBinary(nodeType, @param, constant);
                    }
                }
            }
            return base.VisitBinary(node);
        }
        protected override Expression VisitConstant(ConstantExpression node) {
            constants.Add(node);
            return base.VisitConstant(node);
        }
        protected override Expression VisitParameter(ParameterExpression node) {
            @params.Add(node);
            return base.VisitParameter(node);
        }
        private bool IsSimpleBinaryExpression(Expression node) {
            return node.NodeType == ExpressionType.GreaterThan || node.NodeType == ExpressionType.LessThan;
        }
        private ConstantExpression GetConstantByNodeType(ExpressionType expressionType) {
            var values = constants.Select(c => c.Value);
            var value = expressionType == ExpressionType.GreaterThan ? values.Max() : values.Min();
            return Expression.Constant(value);
        }
    }
