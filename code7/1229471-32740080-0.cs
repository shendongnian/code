    namespace FixVisitor
    {
        class Program
        {
            static void Main(string[] args)
            {
                var person = new Person();
                person.Name = "John";
                Expression<Func<Person, bool>> exp = x => x.Name == FixString(person.Name) && x.Age > 20;
                var modified = new FixVisitor().Visit(exp);
                Console.WriteLine(modified);
            }
    
            static string FixString(string item)
            {
                return item;
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
        }
    
        class Person
        {
            public string Name { get; set; }
    
            public int Age { get; set; }
        }
    }
