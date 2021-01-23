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
    
        public override NHibernate.Hql.Ast.HqlTreeNode BuildHql(MethodInfo method, 
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            NHibernate.Hql.Ast.HqlTreeBuilder treeBuilder,
            NHibernate.Linq.Visitors.IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Dot(
                // using NHibernate.Hql.Ast; required for .AsExpression() to be found
                // at compile time.
                visitor.Visit(arguments[0]).AsExpression(),
                // Below 'Class' method is not 'YourLinqExtensions.Class' extension
                // method. It is natively available on HqlTreeBuilder.
                treeBuilder.Class());
        }
    }
