    public class DistanceConverterTests
    {
        private JsonSerializerSettings _jsonSerializerSettings;
        [SetUp]
        public void Setup()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new DistanceConverter() }
            };
        }
        [Test]
        public void DeserializeTest()
        {
            string json = File.ReadAllText("data.json");
            var distance = JsonConvert.DeserializeObject<Distance>(json, _jsonSerializerSettings);
            distance.Meters.Should().BeInRange(0.360, 0.361);
        }
        [Test]
        public void SerializeTest()
        {
            Distance distance = new Distance(DistanceType.Meter, 2.20);
            string json = JsonConvert.SerializeObject(distance, _jsonSerializerSettings);
            Console.WriteLine(json);
        }
    }
