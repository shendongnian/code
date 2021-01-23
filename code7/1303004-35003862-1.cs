    public class Configuration
    {
        private readonly static Configuration _current = new Configuration();
        public static Configuration Current => _current;
        
        public List<MaterialQuality> MaterialQualities { get; } = new List<MaterialQuality>();
    }
