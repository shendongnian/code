    public abstract class MetaData
    {
        public string Name { get; set; }
    }
    
    public class OldDBMetaData : MetaData
    {
        public string OldName { get; set; }
    }
    
    public class NewDBMetaData : MetaData
    {
        public string NewName { get; set; }
    }
