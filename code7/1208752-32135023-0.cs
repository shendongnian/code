    public class SystemAdministrator
    {
       public string Name { get; set; }
    
       public int LocationId { get; set; } // a complex representation of where this administrator works from
    
       public int UserId { get; set; } // this is now a reference to their log in
    }
