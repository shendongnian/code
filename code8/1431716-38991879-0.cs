    public class CustomFirebirdSQLDialect : FirebirdDialect
    {
        public CustomFirebirdSQLDialect()
        {
            this.RegisterFunction("similar to",
                new SQLFunctionTemplate(
                    NHibernateUtil.Boolean,
                    "?1 similar to ?2"));
        }
    }
    public static class LinqExtensions
    {
        public static bool SimilarTo(this string source, string regex)
        {
            throw new NotImplementedException();
        }
    }
    public class SimilarToGenerator : BaseHqlGeneratorForMethod
    {
        public SimilarToGenerator()
        {
            this.SupportedMethods = new[] { ReflectionHelper.GetMethod(() => LinqExtensions.SimilarTo(null, null)) };
        }
        public override HqlTreeNode BuildHql(
            MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<System.Linq.Expressions.Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            
            return treeBuilder.BooleanMethodCall(
                "similar to",
                arguments.Select(visitor.Visit).Cast<HqlExpression>());
        }
    }
    public class MyLinqToHqlRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public MyLinqToHqlRegistry()
        {
            RegisterGenerator(typeof(LinqExtensions).GetMethod("SimilarTo"), new SimilarToGenerator());
        }
    }
