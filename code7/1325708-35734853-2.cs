    [TestFixture]    
    public  class GivenSomeTest
    {
     
        [Test]
        public void Test()
        {
            TWebDriver driver = new TWebDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            TestContext.CurrentContext.Test.Properties.Add("testCase",methodBase.Name);
        }
        
        [TearDown]
        public void cleanup()
        {
            var testCase = TestContext.CurrentContext.Test.Properties["testCase"];
            string path = (@"..\..\Passor\");
            DateTime timestamp = DateTime.Now;
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                File.WriteAllText(Path.Combine(path, "Failed" + ".txt"), "Failed " + testCase);
            }
            else
            {
                File.WriteAllText(Path.Combine(path, "Passed" + ".txt"), "Passed " + testCase);
            }
        }   
    }
