    public class DateSerialized
    {
        public int date { get; set; }
        public int day { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int month { get; set; }
        public int nanos { get; set; }
        public int seconds { get; set; }
        public long time { get; set; }
        public int timezoneOffset { get; set; }
        public int year { get; set; }
    }
    public class ApiResponse
    {
        [JsonIgnore]
        public DateTimeOffset DateCreated => DateTimeOffset.FromUnixTimeMilliseconds(DateSerialized.time);
        [JsonProperty("dateCreated")]
        private DateSerialized DateSerialized { get; set; }
    }
 
 
