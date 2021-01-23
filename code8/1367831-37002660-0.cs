    [XmlRoot("KAD_Job", Namespace = "root")]
    public class Job
    {
        public Job()
        {
        }
        public int? JobId { get; set; }
        public string JobTitle { get; set; }
        public string CraftCode { get; set; }
        public decimal? Rate { get; set; }
    }
    [XmlRoot("KAD_TASK", Namespace = "root")]
    public class Task
    {
        public Task()
        {
        }
        public int? TaskId { get; set; }
        public string TaskTitle { get; set; }
    }
