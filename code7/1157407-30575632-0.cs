    [TestFixture]
    public class SomeFailingTests
    {
        [Test]
        public void Fails()
        {
            Assert.AreEqual(1, 0);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExceptionExpected()
        {
        }
        [Test]
        public void TestThrows()
        {
            throw new InvalidOperationException();
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThrowsExpected()
        {
            throw new InvalidOperationException();
        }
    }
