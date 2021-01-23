    abstract class BaseConfiguration
    {
        public string SharedConfigProperty { get; set; }
    }
    class LoginConfiguration : BaseConfiguration
    {
        public string LoginConfigProperty { get; set; }
    }
    class TestConfiguration : BaseConfiguration
    {
        public string TestConfigProperty { get; set; }
    }
