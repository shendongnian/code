    [TestFixtureSource("testObjects")]
    public class MySerializerTests
    {
        // IStreamSerializers loaded by the TestCaseSource attribute.
        static IStreamSerializer[] testObjects = new IStreamSerializer[]
        {
            new BinarySerializer(),
            new XmlSerializer(),
            new JsonSerializer()
        };
        IStreamSerializer _serializer;
        public MySerializerTests(IStreamSerializer serializer)
        {
            _serializer = serializer;
        }
        [Test]
        public void Serialize_NullStreamArgument_ThrowsArgumentException()
        {
            Map map = new Map();
            Assert.Throws<ArgumentNullException>(
                () => _serializer.Serialize(null, map));
        }
    }
