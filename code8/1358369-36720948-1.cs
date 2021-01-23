    void Main()
    {
        var data = new List<TestClass>();
        data.Add(new TestClass()
        {
            FirstName = "First",
            LastName = "Last",
        });
    
        var q = data.AsQueryable().Select(x => x.FirstName);
        var vistor = new MyRewriter();
    
        var newExpression = vistor.Visit(q.Expression);
        var output = newExpression.ToString();
        //System.Collections.Generic.List`1[UserQuery+TestClass].Select(x => x.LastName)
    }
    
    class TestClass
    {
        [MyAttribute(nameof(LastName))]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    class MyAttribute : Attribute
    {
        public string MapTo { get; }
        public MyAttribute(string mapTo)
        {
            MapTo = mapTo;
        }
    }
    
    
    class MyRewriter : ExpressionVisitor
    {
        protected override Expression VisitMember(System.Linq.Expressions.MemberExpression node)
        {
            var att = node.Member.GetCustomAttribute<MyAttribute>();
            if (att != null)
            {
                var newMember = node.Expression.Type.GetProperty(att.MapTo);
                if (newMember != null)
                {
                    return Expression.Property(
                        Visit(node.Expression), // Its very important to remember to visit the inner expression
                        newMember);
                }
            }
    
            return base.VisitMember(node);
        }
    }
    
