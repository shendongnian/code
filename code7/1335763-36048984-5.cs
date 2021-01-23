    public class Issue
    {
        public Guid Id { get; set; }   
        [Required]        
        public User ReportedByUser { get; set; }        
        public User ClosedByUser { get; set; }    
    }
