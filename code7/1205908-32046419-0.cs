    public class BaseEntity 
    {
        ...
        public DateTime RevisedDate { get; set; } <---
        public User RevisedBy { get; set; }       <---
    }
    public class Request: BaseEntity 
    {
        ...
    }
    
    public class Material: BaseEntity 
    {
        ...
    }
