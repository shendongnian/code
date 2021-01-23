    namespace FixVisitor
    {
        class Program
        {
            static void Main(string[] args)
            {
                var person = new Person();
                person.Name = "John";
                
                Expression<Func<Person, bool>> exp = x => x.Name == person.Name && x.Age > 20;
                
                var modified = new FixVisitor().Visit(exp);
                Console.WriteLine(modified);
            }
        }
    
        class FixVisitor : ExpressionVisitor
        {
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.Name == "FixString")
                {
                    var item = Expression.Lambda<Func<string>>(node);
                    var value = item.Compile() ();
                    return Expression.Constant(value, typeof(string));
                }
                return base.VisitMethodCall(node);
            }
    
            bool IsMemeberAccessOfAConstant(Expression exp)
            {
                if (exp.NodeType == ExpressionType.MemberAccess)
                {
                    var memberAccess = (MemberExpression) exp;
                    if (memberAccess.Expression.NodeType == ExpressionType.Constant)
                        return true;
                    return IsMemeberAccessOfAConstant(memberAccess.Expression);
                }
    
                return false;
            }
    
            protected override Expression VisitMember(MemberExpression node)
            {
                if (IsMemeberAccessOfAConstant(node) && node.Type == typeof(string))
                {
                    var item = Expression.Lambda<Func<string>>(node);
                    var value = item.Compile()();
                    return Expression.Constant(value, typeof(string));
                }
    
                return base.VisitMember(node);
            }
        }
    
        class Person
        {
            public string Name { get; set; }
    
            public int Age { get; set; }
        }
    }
