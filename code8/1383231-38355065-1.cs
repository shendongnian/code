    [TestMethod, Isolated]
    public void test()
    {
        // Arrange
        string str;
        SomeClass classUnderTest = new SomeClass();
        Isolate.NonPublic.WhenCalled(classUnderTest, "DoSomething").AssignRefOut("test").IgnoreCall();
    
    	// Act
        classUnderTest.foo(out str);
    
    	// Assert
        Assert.AreEqual("test", str);
    }
    
    
    public class SomeClass
    {
        public void foo(out string str)
        {
            DoSomething(out str);
        }
    	
        protected virtual bool DoSomething(out string str) 
        {
            str = "boo";
            return true;
        }
    }
