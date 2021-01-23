    using System.Linq.Expressions;
    // There will never be an implementation of this interface
    // Its only there to "define" the property names and types without
    // magic strings and in a type safe way
    public interface IBaseClassExtension
    {
        public string ExtensionProperty { get; set; }
        public int ExtensionProperty2 { get; set; }
    }
    public class BaseClass
    {
        Dictionary<string, object> propertys = new Dictionary<string, object>();
        public void Add<T, U>(Expression<Func<T, U>> expr, U instance)
        {
            var propExpr = expr.Body as MemberExpression;
            // The declaring types name could be used in addition to be sure there 
            // is no naming conflict with members of other types that have the same member name
            //string name = propExpr.Member.DeclaringType.FullName + propExpr.Member.Name;
            propertys[propExpr.Member.Name] = instance;
        }
        public U Get<T, U>(Expression<Func<T, U>> expr)
        {
            var propExpr = expr.Body as MemberExpression;
            //string name = propExpr.Member.DeclaringType.FullName + propExpr.Member.Name;
            return (U)propertys[propExpr.Member.Name];
        }
        public void Test()
        {
            Add<IBaseClassExtension, string>(bce => bce.ExtensionProperty, "Hello World");
            string helloWorld = Get<IBaseClassExtension, string>(bce => bce.ExtensionProperty);
        }
    }
