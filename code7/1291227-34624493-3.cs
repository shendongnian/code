    [TestClass]
    public class UnitTests
    {
        [TestInitialize]
        public void Setup()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new CustomFloatConverter() }
            };
        }
        [TestMethod]
        public void UndefinedIsTreatedAsNan()
        {
            RootObject obj = JsonConvert.DeserializeObject<RootObject>("{MyValue:undefined}");
            Assert.IsTrue(float.IsNaN(obj.MyValue));
        }
        [TestMethod]
        public void NullIsTreatedAsNaN()
        {
            RootObject obj = JsonConvert.DeserializeObject<RootObject>("{MyValue:null}");
            Assert.IsTrue(float.IsNaN(obj.MyValue));
        }
        [TestMethod]
        public void NumbersAreTreatedNormally()
        {
            RootObject obj1 = JsonConvert.DeserializeObject<RootObject>("{MyValue:1.23}");
            RootObject obj2 = JsonConvert.DeserializeObject<RootObject>("{MyValue:0.0}");
            RootObject obj3 = JsonConvert.DeserializeObject<RootObject>("{MyValue:\"1.23\"}");
            Assert.AreEqual(1.23f, obj1.MyValue);
            Assert.AreEqual(0, obj2.MyValue);
            Assert.AreEqual(1.23f, obj3.MyValue);
        }
    }
