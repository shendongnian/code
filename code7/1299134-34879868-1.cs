    [TestClass]
    public class UnitTest1
    {
       [TestMethod]
        public void TestMethod1()
        {
            MyClass classUnderTest = new MyClass();
            Exception ex;
            try
            {
                Action test = () =>
                {
                    classUnderTest.ThrowMyException();
                };
            }
            catch (Exception exception)
            {
                ex = exception;
            }
            test.ShouldThrow<MyException>();
            ex.ShouldBeOfType<MyException();
            ((MyException)ex).Data.ShouldContain("MyKey");
        }
    }
