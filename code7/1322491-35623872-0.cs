    public class Size
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }
    public class Rotation
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }
    public class Zone
    {
        public string id { get; set; }
        public string type { get; set; }
        public Size size { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }
    }
    public class Area
    {
        public string id { get; set; }
        public string type { get; set; }
        public Size size { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }
        public List<Zone> zones { get; set; }
    }
    public class RootObject
    {
        public Area Area { get; set; }
    }
    var o = JsonConvert.DeserializeObject<RootObject>("json");
