    internal class IgnoreCast : ExpressionVisitor
    {
        protected override Expression VisitUnary(UnaryExpression e)
        {
          if(e.NodeType == ExpressionType.Convert && e.Type.IsAssignableFrom(typeof(e.Operand))
             return e.Operand;
          else
             return e;
        }
    }
