    public class Project
    {
       // Other properties
       public ICollection<Resource> Resources { get; set; }
    }
    
    public class Resource
    {
       // Other properties
       public ICollection<Project> Projects { get; set; }
    }
