    [TestFixture]
    public class MyTests
    {
        private ProductionClass p;
        [SetUp]
        public void Setup()
        {
            p = new ProductionClass();
        }
        // Use the ExpectedException attribute to make sure it threw.
        [Test]
        [ExpectedException(typeof(CustomException)]
        public void Test1()
        {
            p.SomeMethod();
        }
        // Set the ExpectedMessage param to test for a specific message.
        [Test]
        [ExpectedException(typeof(CustomException), ExpectedMessage = "Oh nozzzz!")]
        public void Test2()
        {
            p.SomeMethod();
        }
        // For even more detail, like inspecting the Stack Trace, use Assert.Throws<T>.
        [Test]
        public void Test3()
        {
            var ex = Assert.Throws<CustomException>(() => p.SomeMethod());
            Assert.IsTrue(ex.StackTrace.Contains("Some expected text"));
        }
    }
