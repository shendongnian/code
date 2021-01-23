    class Program
    {
        static void Main(string[] args)
        {
            int param1Value = 2;
            object param2Value = "hello";
            var param1 = Expression.Parameter(typeof(int));
            var param2 = Expression.Parameter(typeof(object));
            var testMethodInfo = typeof(MyClass).GetMethod("TestMethod", BindingFlags.Public | BindingFlags.Static);
            var exp = Expression.Call(testMethodInfo, param1, param2);
            var lambda = Expression.Lambda<Action<int, object>>(exp, param1, param2);
            lambda.Compile().Invoke(param1Value, param2Value);
        }
    }
    static class MyClass
    {
        public static void TestMethod(int param1, object param2)
        {
            Console.WriteLine(param1);
            Console.WriteLine(param2?.ToString());
        }
    }
