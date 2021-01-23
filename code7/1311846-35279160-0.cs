    class Program
    {
        static void Main(string[] args)
        {
            // Test with object:
            object x = new object();
            MethodWithDynamicParameter(x);
            // Test with specific type of object, a string:
            MethodWithDynamicParameter("string");
            Console.ReadKey();
        }
        static void MethodWithDynamicParameter(dynamic dyn)
        {
            MethodWithParams(dyn);
            MethodWithParams(new object[] { dyn });
        }
        static void MethodWithParams(params object[] objects)
        {
        }
    }
