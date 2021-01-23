    public class NamedSoilStat : SoilStat
    {
        public string name { get; set; }
    }
    public class RootObject
    {
        public RootObject() { this.Seed = new List<NamedSoilStat>(); }
        public List<NamedSoilStat> Seed { get; set; }
    }
