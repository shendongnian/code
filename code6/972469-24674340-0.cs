    public class call
    {
        ..... //some other properties you need
        public int StatusId {get;set;}    
        public virtual Status Status {get;set}
    }
    public class Status
    {
        public int Id {get;set;}
        public int Name {get;set;}
    }
