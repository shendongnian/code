    class Program
    {
        static void Main(string[] args)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var abc = ConfigurationManager.AppSettings["abc"];
        }
    }
