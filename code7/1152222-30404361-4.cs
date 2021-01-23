    public class Created
    {
        public string type { get; set; }
        public string format { get; set; }
    }
    
    public class CustomerID
    {
        public string type { get; set; }
    }
    
    public class Deleted
    {
        public string type { get; set; }
    }
    
    public class DocumentID
    {
        public string type { get; set; }
    }
    
    public class Id
    {
        public string type { get; set; }
    }
    
    public class Cert
    {
        public string type { get; set; }
    }
    
    public class ExpDate
    {
        public string format { get; set; }
    }
    
    public class Properties2
    {
        public Cert Cert { get; set; }
        public ExpDate Exp_date { get; set; }
    }
    
    public class Metadata
    {
        public Properties2 properties { get; set; }
    }
    
    public class Properties
    {
        public Created created { get; set; }
        public CustomerID customerID { get; set; }
        public Deleted deleted { get; set; }
        public DocumentID documentID { get; set; }
        public Id id { get; set; }
        public Metadata metadata { get; set; }
    }
    
    public class Basedoc12kja
    {
        public Properties properties { get; set; }
    }
    
    public class Mappings
    {
        public Basedoc12kja basedoc_12kja { get; set; }
    }
    
    public class RootObject
    {
        public Mappings mappings { get; set; }
    }
