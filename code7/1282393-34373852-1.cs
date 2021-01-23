    public class Root
    {
        public List<SoilStat> Soil;
    }
    public class SoilStat
    {
        public string name;
        public int retentionRate;
        public int cost;
    }
    Root root = fastJSON.JSON.ToObject<Root>(jsonString);
