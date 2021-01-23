    public class Program
    {
        private static ITest<string> testVar;
        public static void Main(string[] args)
        {
            testVar = new TestClass();
        }
    }
