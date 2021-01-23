    public class Issue
    {
            public Guid Id { get; set; }   
    
            public Guid ReportedByUserId { get; set; }
            public User ReportedByUser { get; set; }
        
            public Guid ClosedByUserId { get; set; }
            public User ClosedByUser { get; set; }    
    }
