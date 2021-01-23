    public class SubmissionEvent
    {
        [Key]
        public int Id { get; set; }
    
        public virtual Submission Submission { get; set; }
        public string Action { get; set; }
        public DateTime DateTime { get; set; }
    
        public SubmissionEvent() { }
    }
