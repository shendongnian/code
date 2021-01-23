    class Message
    {
        public int ID {
            get;
            set;
        }
        public string Body {
            get;
            set;
        }
    }
    internal static class Program
    {
        private static string SomeMethod(Message m) {
            return "ID";
        }
        private static Expression<Func<Message, object>>[] GetExpressions() {
            string[] props = new[] { "ID", "Name" };
            var expressions =
                props.Select(p => {
                    Expression<Func<Message, object>> exp = m => p;
                    return exp;
                }).ToArray();
            return expressions;
        }
        public class NameResolverExpressionVisitor : ExpressionVisitor
        {
            private Expression<Func<Message, object>> exp;
            public string Name { get; private set; }
            public override Expression Visit(Expression node) {
                var casted = node as Expression<Func<Message, object>>;
                if (casted != null) {
                    exp = casted;
                }
                return base.Visit(node);
            }
            protected override Expression VisitMember(MemberExpression node) {
                var constExpression = node.Expression as ConstantExpression;
                var field = node.Member as FieldInfo;
                if (constExpression != null && field != null) {
                    Name = field.GetValue(constExpression.Value).ToString();
                }
                return base.VisitMember(node);
            }
            protected override Expression VisitMethodCall(MethodCallExpression node) {
                Name = exp.Compile().DynamicInvoke(new Message()).ToString();
                return base.VisitMethodCall(node);
            }
            protected override Expression VisitUnary(UnaryExpression node) {
                var memberExpression = node.Operand as MemberExpression;
                if (memberExpression != null) {
                    Name = memberExpression.Member.Name;
                }
                return base.VisitUnary(node);
            }
            protected override Expression VisitConstant(ConstantExpression node) {
                if (node.Value.GetType().Equals(typeof(string))) {
                    Name = node.Value.ToString();
                }
                return base.VisitConstant(node);
            }
        }
        public static void Main(string[] args) {
            string str = "id";
            Expression<Func<Message, object>> exp1 = m => str;
            Expression<Func<Message, object>> exp2 = m => "id";
            Expression<Func<Message, object>> exp3 = m => m.ID;
            Expression<Func<Message, object>> exp4 = m => SomeMethod(m);
            var expressions = GetExpressions();
            var visitor = new NameResolverExpressionVisitor();
            visitor.Visit(exp1);
            Console.WriteLine(visitor.Name);
            visitor.Visit(exp2);
            Console.WriteLine(visitor.Name);
            visitor.Visit(exp3);
            Console.WriteLine(visitor.Name);
            visitor.Visit(exp4);
            Console.WriteLine(visitor.Name);
            foreach (var exp in expressions) {
                visitor.Visit(exp);
                Console.WriteLine(visitor.Name);
            }
        }
    }
