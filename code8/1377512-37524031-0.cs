    public class Foo
    {
        public virtual string DoSomthing()
        {
            return String.Empty;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var f = MockRepository.GenerateStub<Foo>();
            f.Expect(x => x.DoSomthing())
             .Return("2");
            f.VerifyAllExpectations();
        }
    }
