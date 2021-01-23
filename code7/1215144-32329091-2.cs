    public class TestClass<T> : ITest<T>
    {
        public event EventHandler<ResultEventArgs<T>> ResultReceived;
    }
    public class Program
    {
        private static ITest<string> testVar;
        public static void Main(string[] args)
        {
            testVar = new TestClass<string>();
        }
    }
