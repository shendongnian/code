    public class RootObject
    {
        [JsonProperty("activities-steps")]
        public List<Activity> ActivitesSteps { get; set; }
        [JsonProperty("activities-steps-intraday")]
        public ActivityGranular ActivitiesStepsIntraday { get; set; }
    }
    public class Activity
    {
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class ActivityGranular
    {
        [JsonProperty("dataset")]
        public List<ActivityGranularDatapoint> DataSet { get; set; }
        [JsonProperty("datasetInterval")]
        public int DatasetInterval { get; set; }
        [JsonProperty("datasetType")]
        public string DatasetType { get; set; }
    }
    public class ActivityGranularDatapoint
    {
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("Value")]
        public int Value { get; set; }
    }
