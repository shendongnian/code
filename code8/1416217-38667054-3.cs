	public static class CustomProjections
	{
		static CustomProjections()
		{
			ExpressionProcessor.RegisterCustomProjection(() => IfNull(null, ""), ProcessIfNull);
			ExpressionProcessor.RegisterCustomProjection(() => IfNull(null, 0), ProcessIfNull);
		}
		public static void Register() { }
		public static T IfNull<T>(this T objectProperty, T replaceValueIfIsNull)
		{
			throw new Exception("Not to be used directly - use inside QueryOver expression");
		}
		public static T? IfNull<T>(this T? objectProperty, T replaceValueIfIsNull) where T : struct
		{
			throw new Exception("Not to be used directly - use inside QueryOver expression");
		}
		private static IProjection ProcessIfNull(MethodCallExpression mce)
		{
			var arg0 = ExpressionProcessor.FindMemberProjection(mce.Arguments[0]).AsProjection();
			var arg1 = ExpressionProcessor.FindMemberProjection(mce.Arguments[1]).AsProjection();
			return Projections.SqlFunction("coalesce", NHibernateUtil.Object, arg0, arg1);
		}
	}
