    [TestFixture]
    public class TypeAnalyzerTests
    {
        [TestCase(typeof(string), true)]
        [TestCase(typeof(int), true)]
        [TestCase(typeof(decimal), true)]
        [TestCase(typeof(float), true)]
        [TestCase(typeof(StringComparison), true)]
        [TestCase(typeof(int?), true)]
        [TestCase(typeof(decimal?), true)]
        [TestCase(typeof(StringComparison?), true)]
        [TestCase(typeof(object), false)]
        [TestCase(typeof(Point), false)]
        [TestCase(typeof(Point?), false)]
        [TestCase(typeof(StringBuilder), false)]
        [TestCase(typeof(DateTime), true)]
        public void IsSimple_WhenCalledForType_ReturnsExpectedResult(Type type, bool expectedResult)
        {
            var isSimple = TypeAnalyzer.IsSimple(type);
            Assert.That(isSimple, Is.EqualTo(expectedResult));
        }
    }
