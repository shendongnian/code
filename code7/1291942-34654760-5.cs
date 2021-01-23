    internal class RemoveCastsVisitor : ExpressionVisitor
    {
      private static readonly ExpressionVisitor Default = new RemoveCastsVisitor();
      private RemoveCastsVisitor()
      {
      }
      public new static Expression Visit(Expression node)
      {
        return Default.Visit(node);
      }
      protected override Expression VisitUnary(UnaryExpression node)
      {
        if (node.NodeType == ExpressionType.Convert
            && node.Type.IsAssignableFrom(node.Operand.Type))
        {
          return base.Visit(node.Operand);
        }
        return base.VisitUnary(node);
      }
    }
