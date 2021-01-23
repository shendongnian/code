    public class Root
    {
        public List<Ktype> Ktype { get; set; } = new List<Ktype>();
    }
    public class Ktype
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public bool flag { get; set; }
    }
