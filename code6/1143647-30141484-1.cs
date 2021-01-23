    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
    
    public class Properties
    {
        public string ParselNo { get; set; }
        public string SayfaNo { get; set; }
        public string Alan { get; set; }
        public string Mevkii { get; set; }
        public string Nitelik { get; set; }
        public string CiltNo { get; set; }
        public string Ada { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Pafta { get; set; }
        public string Mahalle { get; set; }
    }
    
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
    
    public class Properties2
    {
        public string name { get; set; }
    }
    
    public class Crs
    {
        public string type { get; set; }
        public Properties2 properties { get; set; }
    }
    
    public class RootObject
    {
        public List<Feature> features { get; set; }
        public string type { get; set; }
        public Crs crs { get; set; }
    }
