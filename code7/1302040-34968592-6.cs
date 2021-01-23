    public class HashAndSize
    {
        public string hash { get; set; }
        public long size { get; set; }
    }
    public class ObjectTable
    {
        public Dictionary<string, HashAndSize> objects { get; set; }
    }
