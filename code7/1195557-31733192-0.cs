    namespace MyNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                /* String splitting and parsing occurs here */
            
                var comparison = Expression.GreaterThan(
                    Expression.Field(null, Type.GetType("MyNamespace.StudentDatabase").GetField("avgHeight")),
                    Expression.Constant(1.7)
                );
                var lambda = Expression.Lambda<Func<bool>>(comparison).Compile();
                StudentDatabase.avgHeight = 1.3;
                var result1 = lambda(); //is true
                StudentDatabase.avgHeight = 2.0;
                var result2 = lambda(); //is false
            }
        }
        class StudentDatabase
        {
            public static double avgHeight = 1.3;
        }
    }
