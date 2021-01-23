    [TestClass]
    public class TestMyDependency {
        [TestMethod]
        public void TestThatMyDependencyIsCalled() {
            var unitUnderTest = new MyDerivedClass();
            var unitUnderTest.Method2();
            /* verify base class behavior #1 inside Method1() */
            /* verify base class behavior #2 inside Method1() */
            /* ... */
        }
    }
