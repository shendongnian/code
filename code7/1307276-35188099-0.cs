    public class Tag
    {
        public Guid TagId { get; set; }
        public string Name { get; set; }
    }
    
    public class ScriptTag
    {
        public Guid ScriptId { get; set; }
        public Guid TagId { get; set; }
        public virtual Script Script { get; set; }
        public virtual Tag Tag { get; set; }
    }
    
    public class Script
    {
        public Guid ScriptId { get; set; }
        public string Title { get; set; }
        ...
    
        public virtual ICollection<ScriptTag> ScriptTags { get; set; }
            = new List<ScriptTag>();
    }
