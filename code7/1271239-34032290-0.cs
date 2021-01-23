    public class User 
    {
        public User() {}
    
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
    
        public string City_Name {get; set;}
        [ForeignKey("City_Name")]
        public virtual City City { get; set; }
    }
    
    public class City
    {
        public City() {}
        [Key]
        public string Name {get; set;}
    }
