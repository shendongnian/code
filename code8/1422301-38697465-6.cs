    public class Data
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("hometown")]
        public Hometown[] Hometown;
        [JsonProperty("bff")]
        public Bff[] Bff;
    }
    public class Bff
    {
        [JsonProperty("people")]
        public People[] People;
        [JsonProperty("id")]
        public string Id;
    }
    public class People
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("name")]
        public string Name;
    }
    public class Hometown
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("name")]
        public string Name;
    }
