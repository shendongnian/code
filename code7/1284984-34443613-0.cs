    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<TestObject, bool>> expr = e => e.FirstName.StartsWith(GetArgument());
            var visitor = new MyExpressionTranslator();
            var translation = visitor.Translate(expr); // = "begins_with(FirstName, Lu)"
        }
        static string GetArgument()
        {
            return "Lu";
        }
    }
    class TestObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public interface IExpressionTranslator<T>
    {
        T Translate(Expression expr);
    }
    public class MyExpressionTranslator : ExpressionVisitor, IExpressionTranslator<string>
    {
        private StringBuilder _sb = null;
        public string Translate(Expression expr)
        {
            _sb = new StringBuilder();
            base.Visit(expr);
            // I need to return the string here
            return _sb.ToString();
        }
        protected override Expression VisitMethodCall(MethodCallExpression expr)
        {
            if (expr.Method.Name == "StartsWith")
            {
                var mainArg = expr.Arguments[0];
                var lambda = Expression.Lambda<Func<string>>(mainArg);
                var arg = lambda.Compile()();
                var member = expr.Object as MemberExpression;
                if (member != null)
                {
                    _sb.AppendFormat("begins_with({0}, {1})", member.Member.Name, arg);
                }
                else
                {
                    //Don't know what you want here.
                    _sb.AppendFormat("begins_with({0}, {1}))", "(obj)", arg);
                }
            }
            return base.VisitMethodCall(expr);
        }
    }
