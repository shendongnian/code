    using NUnit.Framework;
    namespace Foo.Test {
        [TestFixture ()]
        public class TestClass
        {
            [Test ()]
            public void AddTest()
            {
                Assert.AreEqual(30, 15 + 15);
            }
            [Test ()]
            public void Minus()
            {
                Assert.AreEqual(30, 15 - 15);
            }
        }
    }
