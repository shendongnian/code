    public class ConfigData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Reporting { get; set; }
        public int MediaType { get; set; }
        public object MediaServer { get; set; }
        public string MediaServerId { get; set; }
        public object NowStatisticsUrl { get; set; }
        public string StatisticsHubName { get; set; }
        public List<object> Links { get; set; }
        public object Url { get; set; }
    }
    
    public class A
    {
        public ConfigData configData { get; set; }
        public string Status { get; set; }
        public double LongestWaiting { get; set; }
        public int Acd { get; set; }
        public int NonAcd { get; set; }
        public int Out { get; set; }
        public int Unavailable { get; set; }
        public int Offered { get; set; }
        public int Handled { get; set; }
        public int Abandoned { get; set; }
        public int Interflow { get; set; }
        public int Requeue { get; set; }
        public int ServiceLevel { get; set; }
        public int AgentsIdle { get; set; }
        public int ItemsWaiting { get; set; }
        public bool QueueOpen { get; set; }
        public int AgentsLoggedIn { get; set; }
        public int AgentsAvailable { get; set; }
        public double EstimatedWaitTime { get; set; }
        public int AverageHandlingTime { get; set; }
        public object DetailsUrl { get; set; }
    }
    
    public class RootObject
    {
        public string H { get; set; }
        public string M { get; set; }
        public List<A> A { get; set; }
    }
