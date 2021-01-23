    [TestFixture("sendSomethingToConstructor")]
    class TestClass
    {
        public TestClass(string parameter){}
        
        [TestCase(123)] //for parameterized methods
        public void TestMethod(int number){}
        [Test] //for methods without parameters
        public void TestMethodTwo(){}
        [TearDown]//after each test run
        public void CleanUp()
        {
                
        }
        
        [SetUp] //before each test run
        public void SetUp() 
        {
     
        }
    }
