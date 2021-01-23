    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnumToStringSerialization()
        {
            var testMe = new TestMe()
            {
                UserType = UserType.User,
            };
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());
            var jsonString = JsonConvert.SerializeObject(testMe, settings);
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
