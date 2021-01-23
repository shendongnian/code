    [TestClass]
    class Test {
        [TestMethod]
        public void TestMethod() {
            // Arrange
            IPathProvider fakePathProvider = new FakePathProvider();
            Account ac = new Account(fakePathProvider);
    
            // Act
            // ...other test code
        }
    }
