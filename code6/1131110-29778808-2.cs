    public class Program
    {
        public static void Main(string[] args)
        {
            string assemblyPath = @"path";
            XunitFrontController controller = new XunitFrontController(
                assemblyPath);
            TestAssemblyConfiguration assemblyConfiguration = new TestAssemblyConfiguration();
            ITestFrameworkDiscoveryOptions discoveryOptions = TestFrameworkOptions.ForDiscovery(assemblyConfiguration);
            ITestFrameworkExecutionOptions executionOptions = TestFrameworkOptions.ForExecution(assemblyConfiguration);
            IMessageSink messageSink = new CustomTestMessageVisitor<ITestMessage>();
            
            Console.WriteLine("Running tests");
            controller.RunAll(
                messageSink: messageSink,
                discoveryOptions: discoveryOptions,
                executionOptions: executionOptions);
        }
    }
    public class CustomTestMessageVisitor<T> : TestMessageVisitor<T> where T : ITestMessage
    {
        protected override bool Visit(ITestFinished message)
        {
            Console.WriteLine("Test {0} finished.",
                message.Test.DisplayName);
            return true;
        }
        protected override bool Visit(ITestPassed message)
        {
            Console.WriteLine("Test {0} passed", message.Test.DisplayName);
            return true;
        }
        protected override bool Visit(ITestFailed message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string exceptionType in message.ExceptionTypes)
            {
                stringBuilder.AppendFormat("{0}, ", exceptionType);
            }
            Console.WriteLine("Test {0} failed with {1}", 
                message.Test.DisplayName, 
                stringBuilder.ToString());
            return true;
        }
    }
    
    
