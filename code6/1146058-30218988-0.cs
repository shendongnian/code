    [Table(Name = "orgs")]
    public class Organization
    {
        public Organization()
        {
    
        }
    
        
        [Column(IsDbGenerated=true)]
        public int orgid { get; set; }
        [Column]
        public string orgname { get; set; }
    } 
