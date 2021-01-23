    [TestMethod]
    public void TestCaseMethod()
    {        
        // Set up
        Mock<ITestClass> testM = new Mock<ITestClass>();
        AnimalClass instance = new AnimalClass(testM.Object);
    
        // call the method under test
        AssertException<ArgumentException>(instance.MethodUnderTest)
    }
