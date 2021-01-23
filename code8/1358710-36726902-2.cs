    [TestClass]
    public class TestMyDependency {
        [TestMethod]
        public void TestThatMyDependencyIsCalled() {
            var dependency = new Mock<IUsedToBeBaseClass>();
            var unitUnderTest = new MyClass(dependency.Object);
            var unitUnderTest.Method2();
            dependency.Verify(x => x.Method1(), Times.Once);
        }
    }
