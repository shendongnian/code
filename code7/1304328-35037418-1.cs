            [TestMethod]
            Public Void TestReferenceFor100()
            {
                //Eg: if an invalid number returns null, then we test valid numbers
               MyClass class = new MyClass();
               Assert.NotNull(class.DoSomething(100));
            }
            [TestMethod]
            Public Void TestReferenceFor500()
            {
                //Eg: if an invalid number returns null, then we test valid numbers
               MyClass class = new MyClass();
               Assert.NotNull(class.DoSomething(500));
            }
                [TestMethod]
            Public Void TestReferenceFor99()
            {
                //Eg: Now test some negative edge cases
               MyClass class = new MyClass();
               Assert.IsNull(class.DoSomething(99));
            }
                    [TestMethod]
            Public Void TestReferenceFor501()
            {
                //Eg: Now test some negative edge cases
               MyClass class = new MyClass();
               Assert.IsNull(class.DoSomething(501));
            }
    public class MyClass
        {
            public void DoSomething(int i)
            {
                // Do something here
            }
        }
