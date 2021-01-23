    public class AsNullableGenerator : BaseHqlGeneratorForMethod,
        IRuntimeMethodHqlGenerator
    {
        private static readonly HashSet<MethodInfo> ActingMethods =
            new HashSet<MethodInfo>
            {
                ReflectionHelper.GetMethod<char>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<sbyte>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<byte>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<short>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<ushort>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<int>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<uint>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<long>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<ulong>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<float>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<double>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<decimal>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<Guid>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<DateTime>(x => x.AsNullable()),
                ReflectionHelper.GetMethod<DateTimeOffset>(x => x.AsNullable())
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
            // null conversion.
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
