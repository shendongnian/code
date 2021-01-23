    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "activities-steps")]
        public Activity[] activity_steps { get; set; }
        [DataMember(Name = "activities-steps-intraday")]
        public ActivityGranular activity_granular { get; set; }
        
    }
    public class Activity
    {
        public string dateTime { get; set; }
        public string value { get; set; }
    }
    [DataContract]
    public class ActivityGranular
    {
        public List<ActivityGranularDatapoint> dataset { get; set; }
        [DataMember(Name = "datasetInterval")]
        public string datasetGranularity { get; set; }
        [DataMember(Name = "datasetType")]
        public string datasetGranularityType { get; set; }
    }
    public class ActivityGranularDatapoint
    {
        public string time { get; set; }
        public int value { get; set; }
    }
