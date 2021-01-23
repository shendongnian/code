    [TestClass]
    public class JsonStringTest
    {
        [TestMethod]
        public void EnumToStringSerializationTest()
        {
            var testMe = new TestMe()
            {
                UserType = UserType.User,
            };
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());
            var jsonString = JsonConvert.SerializeObject(testMe, settings);
            Assert.AreEqual(jsonString, "{\"UserType\":\"User\"}");
        }
    }
    public class TestMe
    {
        public UserType UserType { get; set; }
    }
    public enum UserType
    {
        Admin = 1,
        User = 2
    }
