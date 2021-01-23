    [TestFixture]
    public class GivenSomeTest
    {
        private string _testCase;
        [Test]
        public void Test()
        {
            TWebDriver driver = new TWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            _testCase = methodBase.Name;
        }
        
        [TearDown]
        public void cleanup()
        {
            string path = (@"..\..\Passor\");
            DateTime timestamp = DateTime.Now;
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                File.WriteAllText(Path.Combine(path, "Failed" + ".txt"), "Failed " + _testCase);
            }
            else
            {
                File.WriteAllText(Path.Combine(path, "Passed" + ".txt"), "Passed " + _testCase);
            }
        }   
    }
