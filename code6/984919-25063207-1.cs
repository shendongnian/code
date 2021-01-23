    class RootObject
    {
        [JsonProperty("results")]
        public Results Results { get; set; }
    }
    
    class Results
    {
        [JsonProperty("jobcodes")]
        public Dictionary<string, JobCode> JobCodes { get; set; }
    }
    class JobCode
    {
        [JsonProperty("_status_code")]
        public string StatusCode { get; set; }
        [JsonProperty("_status_message")]
        public string StatusMessage { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
