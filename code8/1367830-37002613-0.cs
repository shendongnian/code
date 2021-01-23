      [XmlType(TypeName = "Task",
          Namespace = "Tester.Staff")]
        public class Task
        {
            public int? TaskId { get; set; }
            public string TaskTitle { get; set; }
            public bool? OverAllTaskCompetency { get; set; }
            public DateTime? ExpireyOfNextCompetencyOrLicenceForTask { get; set; }
        }
    
        [XmlType(TypeName = "Job",
             Namespace = "Tester.Staff")]
        public class Job
        {
            public Job()
            {
                Tasks = new List<Task>();
            }
    
            public int? JobId { get; set; }
            public string JobTitle { get; set; }
            public decimal? Rate { get; set; }
            public List<Task> Tasks { get; set; }
        }
