    public class ConvertToInt64HqlGenerator : BaseHqlGeneratorForMethod
    {
        public ConvertToInt64HqlGenerator()
            : base()
        {
            this.SupportedMethods = new[] { ReflectionHelper.GetMethodDefinition(() => Convert.ToInt64("")),
                                            ReflectionHelper.GetMethodDefinition(() => Convert.ToInt64(0)),
                                            ReflectionHelper.GetMethodDefinition(() => Convert.ToInt64(0M))};
        }
        public override HqlTreeNode BuildHql(MethodInfo method,
                                                Expression targetObject,
                                                ReadOnlyCollection<Expression> arguments,
                                                HqlTreeBuilder treeBuilder,
                                                IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Cast(visitor.Visit(arguments[0]).AsExpression(),typeof(Int64));
        }
    }
