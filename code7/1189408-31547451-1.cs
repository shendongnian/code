    [TestFixture]
    public class VRemoverTests
    {
        [Test]
        public void Test()
        {
            var inputs = new[]
            {
                "ABCD12345678",
                "ABCD1234",
                "ABCD1233456v1",
                "ABCD1233456v2",
                "AVVV1233456v334",
                "ABVV1233456V4"
            };
            var expecteds = new[]
            {
                "ABCD12345678",
                "ABCD1234",
                "ABCD1233456",
                "ABCD1233456",
                "AVVV1233456",
                "ABVV1233456"
            };
            for (var i = 0; i < inputs.Length; i++)
            {
                var actual = VRemover.Process(inputs[i]);
                Assert.AreEqual(expecteds[i], actual);
            }
        }
    }
