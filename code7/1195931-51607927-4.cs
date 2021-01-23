	public class ExpressionRef : Expression
	{
		public override ExpressionType NodeType => ExpressionType.Extension;
		public override Type Type => Node.Type;
		public override bool CanReduce => true;
		public Expression Node;
		public override Expression Reduce() => Node;
		public override String ToString() => "&" + Node;
	};
