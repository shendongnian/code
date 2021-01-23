    [TextFixture]
    public class FooTests
    {
        [Test]
        [TestCase(200)]
        [TestCase(2)]
        public void ReturnsValidHeight(int expectedHeight)
        {
            var foo = new Foo { Height = new FooHeight(expectedHeight) };
            Assert.AreEqual(expectedHeight, foo.Height);
        }
    }
    
