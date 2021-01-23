    [JsonConverter(typeof(StatisticConverter))]
    public class Statistic
    {
        public DateTime ProjectDate { get; set; }
        public Decimal Sale { get; set; }
    }
