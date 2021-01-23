    public class ReportGroup
    {
        public int Id { get; set; }
        public string ReportGroupName { get; set; }
        public object ReportGroupNameResID { get; set; }
        public int SortOrder { get; set; }
        public List<object> items { get; set; }
        public int index { get; set; }
    }
    
    public class RootObject
    {
        public List<ReportGroup> reportGroups { get; set; }
    }
