    [JsonConverter(typeof(BadDataEntityConverter))]
    public class BadDataEntity
    {
        [Key]
        public int ID { get; set; }
        public string BadData { get; set; }
    }
