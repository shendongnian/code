    class VersionInfo
    {
        public int BuildVersion { get; set; }
        public String DataCenterId { get; set; }
    
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime Heartbeat { get; set; }
        public Guid ID { get; set; }
    }
    
    static void Main(string[] args)
    {
        String json = @"
            [
                {
                    ""BuildVersion"": 0,
                    ""DataCenterId"": ""LD5"",
                    ""Heartbeat"": 1458060298923,
                    ""ID"": ""0393ceb7-92cf-45f6-8cea-ac25878598e3""
                }
            ]";
        var versionInfo = JsonConvert.DeserializeObject<IList<VersionInfo>>(json);
    }
