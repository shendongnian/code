    public enum CrudAction
    {
        Create,
        Read,
        Update,
        Delete
    }
    
    public sealed class CrudRequestHeader
    {
        public CrudAction Action { get; set; }
    
        public string Object { get; set; }
    
        public string User { get; set; }
    }
    
    public sealed class RuleDefinition
    {
        public string Name { get; set; }
        
        public string Value { get; set; }
    }
    
    public sealed class CrudRequest
    {
        public CrudRequestHeader Head { get; set;}
    
        public Dictionary<string, string> Object { get; set; }
    
        public List<RuleDefinition> Rule { get; set; }
    }
