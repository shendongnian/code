    public class Application
    {
        public virtual SQuery sQuery { get; set; }
        ...
    }
    public class SQuery
    {
        // wrong, Guid is ValueType, not a reference 
        // public virtual Guid Application { get;set; } 
        // corrrect - one to one == bi-directional 
        public virtual Application Application { get;set; } 
        ...
    }
