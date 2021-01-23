    [TestClass]
    public class DerivedTestClass : BaseIngetrationTests
    {
        public override void BaseTestCleanup()
        {
            // Derived cleanup
            base.BaseTestCleanup();
        }
        [TestMethod]
        public void SomeMethod_SomeCriteria_SomeResult()
        {
            // Arrange
            // Act
            // Assert
        }
    }
