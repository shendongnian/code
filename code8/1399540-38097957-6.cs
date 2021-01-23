    public class IncludeVisitor : ExpressionVisitor
    {
        private static IncludeVisitor _visitor;
        private static List<string> _includes;
        private IncludeVisitor() {}
        static IncludeVisitor()
        {
            _visitor = new IncludeVisitor();
        }
        public static List<string> GetIncludes(Expression expr)
        {
            _includes = new List<string>();
            _visitor.Visit(expr);
            return _includes;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if(node.Method.Name == "Include" || node.Method.Name == "IncludeSpan")
            {
                try
                {
                    var spanList = node.Arguments.First().GetPrivatePropertyValue("Value")
                                                         .GetPrivatePropertyValue("SpanList");
                    var navigations = ((IEnumerable<object>)spanList)
                                         .Select(s => s.GetPrivateFieldValue("Navigations"));
                    foreach (var nav in navigations)
                        _includes.AddRange(((IEnumerable<string>)nav).ToList());
                }
                catch { }
            }
            return base.VisitMethodCall(node);
        }
    }
