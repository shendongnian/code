    public class Project
    {
        public string Id { get; set; }
        public List<Issue> Issues { get; set; }
    }
    public class Issue
    {
        public string IssueId { get; set; }
        public List<IssueFile> Files { get; set; }
    }
    public class IssueFile
    {
        public string Name { get; set; }
    }
