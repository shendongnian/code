    [TestClass]
    public class UnitTest1
    {
       [TestMethod]
        public void TestMethod1()
        {
            MyClass classUnderTest = new MyClass();
            Exception ex;
            Action test = () =>
            {
                ex = classUnderTest.ThrowMyException();
            };
            test.ShouldThrow<MyException>();
            ex.ShouldBeOfType<MyException();
            ((MyException)ex).Data.ShouldContain("MyKey");
        }
    }
