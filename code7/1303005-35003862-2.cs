    public class Configuration
    {
        private readonly static Configuration _current = new Configuration();
        private readonly List<MaterialQuality> _materialQualities = new List<MaterialQuality>();
       
        public static Configuration Current => _current;
        
        public IImmutableList<MaterialQuality> MaterialQualities => _materialQualities.ToImmutableList();
        public Configuration AddMaterial(float value, int cost) => 
             _materialQualities.Add(new MaterialQuality { Value = value, Cost = cost });
    }
