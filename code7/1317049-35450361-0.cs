    public abstract class BaseConfiguration
    {
        static BaseConfiguration()
        {
            Filenames = new Dictionary<Type, string>
            {
                { typeof(LoginConfiguration), "login.xml" },
                { typeof(TestConfiguration), "test.xml" },
            };
        }
    
        private static Dictionary<Type, string> Filenames { get; }
    
        public static string GetFilename<TConfig>() where TConfig : BaseConfiguration
        {
            return Filenames[typeof(TConfig)];
        }
    }
