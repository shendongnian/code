    public class ClassGenerator : NHibernate.Linq.Functions.BaseHqlGeneratorForMethod
    {
        public ClassGenerator()
        {
            SupportedMethods = new[]
            {
                NHibernate.Linq.ReflectionHelper.GetMethod(
                    () => YourLinqExtensions.Class(null))
            };
        }
    
        public override HqlTreeNode BuildHql(MethodInfo method, 
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            NHibernate.Hql.Ast.HqlTreeBuilder treeBuilder,
            NHibernate.Linq.Visitors.IHqlExpressionVisitor visitor)
        {
            // Below 'Class' method is not 'YourLinqExtensions.Class' extension method.
            // It is natively available on HqlTreeBuilder.
            return treeBuilder.Class();
        }
    }
