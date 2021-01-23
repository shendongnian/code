    public class ParameterReplacer : ExpressionVisitor
	{
		private readonly ParameterExpression m_parameter;
		private readonly Expression m_replacement;
		public ParameterReplacer(ParameterExpression parameter, Expression replacement)
		{
			this.m_parameter = parameter;
			this.m_replacement = replacement;
		}
		
		protected override Expression VisitParameter(ParameterExpression node)
		{
			if (object.ReferenceEquals(node, m_parameter))
				return m_replacement;
			return node;
		}
		
	}
