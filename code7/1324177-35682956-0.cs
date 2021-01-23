    public class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression _oldExpr;
        private readonly Expression _newExpr;
    
        public ReplaceVisitor(Expression oldExpr, Expression newExpr)
        {
            _oldExpr = oldExpr;
            _newExpr = newExpr;
        }
    
        public override Expression Visit(Expression node)
        {
            if (node == _oldExpr)
            {
                return _newExpr;
            }
            return base.Visit(node);
        }
    }
---
    public UpdateExpressionVisitor(ParameterExpression oldExpr, Expression newExpr)
