    public class Test
    {
        public static class Met1
        {
            public static void _Validate(string gp)
            {
                Console.WriteLine(gp);
            }
        }
    }
    MethodInfo method = typeof(Test.Met1).GetMethod("_Validate");
    // Or 
    // MethodInfo method = typeof(Test.Met1).GetMethod("_Validate", BindingFlags.Static | BindingFlags.Public);
    // or
    // MethodInfo method = typeof(Test.Met1).GetMethod("_Validate", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string) }, null);
    method.Invoke(null, new object[] { "Hello world " });
