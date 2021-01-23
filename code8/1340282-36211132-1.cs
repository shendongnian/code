    public class AsNullableGenerator : BaseHqlGeneratorForMethod,
        IRuntimeMethodHqlGenerator
    {
        private static readonly HashSet<MethodInfo> ActingMethods =
            new HashSet<MethodInfo>
            {
                ReflectionHelper.GetMethodDefinition<char>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<sbyte>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<byte>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<short>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<ushort>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<int>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<uint>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<long>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<ulong>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<float>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<double>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<decimal>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<Guid>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<DateTime>(x => x.AsNullable()),
                ReflectionHelper.GetMethodDefinition<DateTimeOffset>(
                    x => x.AsNullable())
            };
        public AsNullableGenerator()
        {
            // Explicitly declared types support.
            SupportedMethods = ActingMethods.ToArray();
        }
        public override HqlTreeNode BuildHql(MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            // Just have to skip, HQL does not need 'explanations' on
            // null convertion.
            return visitor.Visit(arguments[0]).AsExpression();
        }
        public bool SupportsMethod(MethodInfo method)
        {
            return ActingMethods.Contains(method) ||
                // Non explicitly declared types support, through inspection.
                (method != null && method.Name == "AsNullable" &&
                    method.DeclaringType == typeof(NullableExtensions));
        }
        public IHqlGeneratorForMethod GetMethodGenerator(MethodInfo method)
        {
            return this;
        }
    }
