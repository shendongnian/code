    using System;
    using System.Linq.Expressions;
    
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            ShowMemberType<Person>(p => p.Age);
            ShowMemberType<Person>(p => p.Name);
        }
        
        static void ShowMemberType<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body;
            // Unwrap the conversion to object, if there is one.
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }
            Console.WriteLine("Type: {0}", body.Type);
        }
    }
