    public class ProjectTree
    {
        public List<Project> data { get; set; }
    }
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Project> children { get; set; }
    }
