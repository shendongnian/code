    public class RootObject
    {
        public Dictionary<string, PathData> files { get; set; }
    }
    public class PathData
    {
        public int size { get; set; }
        public string data { get; set; }
        public string data2 { get; set; }
    }
