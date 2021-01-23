    class Response2
    {
        [JsonProperty("in_progress")]
        public int InProgress { get; set; }
    
        [JsonProperty("completed")]
        public int Completed { get; set; }
    
        [JsonProperty("passed")]
        public int Passed { get; set; }
    
        [JsonProperty("course_progress")]
        public Dictionary<string, CourseProgress> CourseProgress { get; set; }
    }
    class CourseProgress
    {
        [JsonProperty("course_name_en")]
        public string CourseNameEn { get; set; }
    }
