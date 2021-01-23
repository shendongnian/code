    using System;
    using System.Linq.Expressions;
    
    public class Test
    {    
        static void Main()
        {
            var x = Expression.Variable(typeof(int), "x");
            var assignment1 = Expression.Assign(x, Expression.Constant(1, typeof(int)));
            var assignment2 = Expression.Assign(x, Expression.Constant(2, typeof(int)));
            
            var block = Expression.Block(new[] { x }, new[] { assignment1, assignment2 });
        }
    }
