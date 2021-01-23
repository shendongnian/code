    public class Request
    {
        public string command { get; set; }
        public string project_id { get; set; }
    }
    public class Project
    {
        public string project_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public string dept { get; set; }
        public string modified { get; set; }
        public List<List<object>> data { get; set; }
    }
    public class RootObject
    {
        public Request request { get; set; }
        public List<Project> project { get; set; }
    }
