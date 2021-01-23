    public class BuildRequest
    {
        [JsonProperty(PropertyName = "definition")]
        public Definition Definition { get; set; }
        [JsonProperty(PropertyName = "demands")]
        public string Demands { get; set; }
        [JsonProperty(PropertyName = "parameters")]
        public IEnumerable<string> Parameters { get; set; }
        [JsonProperty(PropertyName = "project")]
        public Project Project { get; set; }
        [JsonProperty(PropertyName = "queue")]
        public Queue Queue { get; set; }
        [JsonProperty(PropertyName = "reason")]
        public int Reason { get; set; }
        [JsonProperty(PropertyName = "sourceBranch")]
        public string sourceBranch { get; set; }
        [JsonProperty(PropertyName = "sourceVersion")]
        public string RequestedBy { get; set; }
    }
    public class Definition
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
    public class Queue
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
    public class Project
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
