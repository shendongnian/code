    [TestFixture]
    public class Tests
    {
        [Test]
        public void Normal()
        {
            var actual = new Dictionary<string, object> {{"iss", "abc"}};
            actual.Should().FirstKeyMatchesAndValueInvariantMatch("iss", "ABC");
        }
    }
