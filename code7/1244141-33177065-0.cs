    using System.Linq.Expressions;
    using myAlias = System.Linq.Dynamic;
    
    namespace ConsoleApplication11
    {
        public class Foo
        {
            public string Bar { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var expression = @"(Foo.Bar == ""barbar"")";
                var p = Expression.Parameter(typeof(Foo), "Foo");
                var e = myAlias.DynamicExpression.ParseLambda(new[] { p }, null, expression);
    
                var test1 = new Foo()
                {
                    Bar = "notbarbar",
    
                };
    
                var test2 = new Foo()
                {
                    Bar = "barbar"
                };
    
                // false
                var result1 = e.Compile().DynamicInvoke(test1);
    
                // true
                var result2 = e.Compile().DynamicInvoke(test2);
            }
        }
    }
