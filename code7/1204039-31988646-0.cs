        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("source_code")]
        public string source_code { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("data")]
        public List<Dictionary<string,double>> data { get; set; }
    }
