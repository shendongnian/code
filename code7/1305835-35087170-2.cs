    public interface IConfig { }
    public class Config1 : IConfig
    {
        public static Config1 Config = new Config1();
        private Config1()
        {
            FileName = "file.xml";
        }
        public string FileName { get; private set; }
    }
