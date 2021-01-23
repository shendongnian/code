    public class Event     
    {
        public int ID { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<CLIENTEVENT> links { get; set; }
    }
    
    public class Company
    {
        public int ID { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<CLIENTEVENT> links { get; set; }
    }
    
    public class PERSON
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
    
        public virtual ICollection<CLIENTEVENT> links { get; set; }
    }
    
    public class CLIENTEVENT
    {
        public int ID { get; set; }
    
        public virtual PERSON person { get; set; }
        public int? personID { get; set; }
    
        public virtual Company company { get; set; }
        public int? companyID { get; set; }
    
        public virtual Event event1 { get; set; }
        public int? event1ID { get; set; }
    }
