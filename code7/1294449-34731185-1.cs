    [JsonConverter(typeof(NumberAndSecondaryStatConverter))]
    public class NumberAndSecondaryStat
    {
        public DataItem[] DataItems { get; set; }
        public List<string> TrendData { get; set; }
    }
