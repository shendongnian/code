	public class ExpressionReplacer : ExpressionVisitor
	{
		public Expression From;
		public Expression To;
		protected override Expression VisitParameter(ParameterExpression node)
		{
			if (node == From)
			{
				return base.Visit(To);
			}
			return base.VisitParameter(node);
		}
	}
