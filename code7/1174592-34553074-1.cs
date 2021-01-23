    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ConsoleOutToTestWriterAttribute : TestActionAttribute
    {
        public override void BeforeTest(TestDetails testDetails)
        {
            // If the test has a [TestWriter], redirect Console.Out to its "Output" property
            var output = TestContext.CurrentContext.Test.Properties["Output"] as StringBuilder;
            if (output != null) 
                Console.SetOut(new System.IO.StringWriter(output));
            _consoleOutRedirected = output != null;
        }
        public override void AfterTest(TestDetails testDetails)
        {
            // Reset Console.Out, if appropriate
            if(_consoleOutRedirected)
                Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
        public override ActionTargets Targets
        {
            // needs to apply to each test, since [TestWriter]s are applied per test
            get { return ActionTargets.Test; }
        }
        private bool _consoleOutRedirected;
    }
