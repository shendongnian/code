    using System;
    using System.Linq.Expressions;
    
    public class Model
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    
    public class Test
    {
        public static void Main()
        {
            Expression<Func<Model, bool>> original = x => x.Name == "Fred";
            var parameter = original.Parameters[0];
            var dateClause = Expression.LessThanOrEqual(
                Expression.Property(parameter, "Date"),
                Expression.Constant(new DateTime(2015, 1, 1), typeof(DateTime)));
            var combined = Expression.AndAlso(original.Body, dateClause);
            var tree = Expression.Lambda<Func<Model, bool>>(combined, parameter);
            Console.WriteLine(tree);
        }
    }
