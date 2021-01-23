    public class Computer 
    {
        public virtual int Id{ get; set; }
        public virtual string Hostname { get; set; }
        ...
        public int OwnerId;
        public int? ContactId;
        [ForeignKey("OwnerId")]
        public virtual Person Owner{ get; set; }
        [ForeignKey("ContactId")]
        public virtual Person Contact { get; set; }
    }
    
