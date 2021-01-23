    public class tableA
    {
        public int Id { get; set; }
    
        public string desc { get; set; }
    
        public tableB tableB { get; set; }
    }
    
    public class tableB
    {
        // In one-to-one relationship, one end must be principal and second end must be dependent. 
        // tableA is the one which will be inserted first and which can exist without the dependent one. 
        // tableB end is the one which must be inserted after the principal because it has foreign key to the principal.
    
        [Key, ForeignKey("tableA")]
        public int Id { get; set; }
    
        // 'Required' attribute because tableA must be present
        // in order for a tableB to exist
        [Required]
        public virtual tableA tableA { get; set; }
    
        public string somedesc { get; set; }
    }
