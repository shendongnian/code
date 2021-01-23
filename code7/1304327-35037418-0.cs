            [TestMethod]
            Public Void TestReferenceVulnarability()
            {
                MyClass _myClass = new MyClass();
                //Do something
                Assert.NotNull(myClass.DoSomething);
            }
    
    public class MyClass
        {
            public void DoSomething()
            {
                // Do something here
            }
        }
