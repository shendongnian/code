    public class Assignee
    {
        public string ID { get; set; }
        public bool IsPrimaryOffice { get; set; }
    }
    
    public class RootObject
    {
        public List<Assignee> Assignees { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Top { get; set; }
        public string Left { get; set; }
    }
