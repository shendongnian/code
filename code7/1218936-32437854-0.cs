        public class ApiEndPoint // you will find a better name, I'm sure
        {
            public string notificationId { get; set; }
            public string readFlag { get; set; }
            public string importantFlag { get; set; }
            public string subject { get; set; }
            public string folder { get; set; }
            public DateTime creationTime { get; set; }
            public int notificationCount { get; set; }
            public string jobId { get; set; }
            public Dictionary<string, string> recruitersMap { get; set; }
            public Dictionary<string, string> jobsMap { get; set; }
        }
