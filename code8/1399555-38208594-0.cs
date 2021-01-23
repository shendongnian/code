    internal static class IncludeVisitorExtensions
    {
        public static object GetPrivatePropertyValue( this object obj, string propName )
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty( propName, BindingFlags.Public
                                            | BindingFlags.NonPublic | BindingFlags.Instance );
            return propertyInfo.GetValue( obj, null );
        }
        public static object GetPrivateFieldValue( this object obj, string fieldName )
        {
            FieldInfo fieldInfo = obj.GetType().GetField( fieldName, BindingFlags.Public
                                         | BindingFlags.NonPublic | BindingFlags.Instance );
            return fieldInfo?.GetValue( obj );
        }
    }
    internal class IncludeVisitor : ExpressionVisitor
    {
        private static readonly IncludeVisitor Visitor;
        private static List<string> _includes;
        private IncludeVisitor() { }
        static IncludeVisitor()
        {
            Visitor = new IncludeVisitor();
        }
        public static ICollection<string> GetIncludes( Expression expr )
        {
            _includes = new List<string>();
            Visitor.Visit( expr );
            return _includes;
        }
        protected override Expression VisitMethodCall( MethodCallExpression node )
        {
            if (node.Method.Name != "Include" && node.Method.Name != "IncludeSpan")
                return base.VisitMethodCall( node );
            //"Include" == .Where() is present in the query
            //"IncludeSpan" == no .Where() in the query
            try
            {
                if (node.Method.Name == "Include")
                {
                    string includedObjectName = (string) node.Arguments.First().GetPrivatePropertyValue("Value");
                    if (includedObjectName != null)
                    {
                        _includes.Add(includedObjectName);
                    }
                }
                else if (node.Method.Name == "IncludeSpan")
                {
                    var spanList =
                        node.Arguments.First().GetPrivatePropertyValue("Value").GetPrivatePropertyValue("SpanList");
                    var navigations = ((IEnumerable<object>) spanList).Select(s => s.GetPrivateFieldValue("Navigations"));
                    foreach (var nav in navigations)
                        _includes.Add(string.Join(".", (IEnumerable<string>) nav));
                }
            }
            catch (Exception e) { }
            return base.VisitMethodCall( node );
        }
    }
