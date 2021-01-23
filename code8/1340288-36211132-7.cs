	public class AsNullableGenerator : BaseHqlGeneratorForMethod
	{
		private static readonly MethodInfo AsNullableDefinition = ReflectionHelper.GetMethodDefinition(() => NullableExtensions.AsNullable(0));
		public AsNullableGenerator()
		{
			SupportedMethods = new[] { ReflectionHelper.GetMethodDefinition(() => NullableExtensions.AsNullable(0)) };
		}
		public override HqlTreeNode BuildHql(MethodInfo method,
			Expression targetObject,
			ReadOnlyCollection<Expression> arguments,
			HqlTreeBuilder treeBuilder,
			IHqlExpressionVisitor visitor)
		{
			// Just have to transmit the argument "as is", HQL does not need a specific call for
			// null conversion.
			return visitor.Visit(arguments[0]).AsExpression();
		}
		public IHqlGeneratorForMethod GetMethodGenerator(MethodInfo method)
		{
			return this;
		}
	}
