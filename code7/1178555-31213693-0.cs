        class subjects
        {
            [JsonProperty("subject_id")]
            public int id { get; set; }
            [JsonProperty("subject_name")]
            public string name { get; set; }
            [JsonProperty("subject_class")]
            public int class_name { get; set; }
            [JsonProperty("subject_year")]
            public string year { get; set; }
            [JsonProperty("subject_code")]
            public string code { get; set; }
        }
