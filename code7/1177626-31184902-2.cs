    class Friendship
    {
        [Key]
        public int id { get; set; }
    
        [ForeignKey("who")]
        public int whoid { get; set; }
    
        [ForeignKey("whom")]
        public int whomid { get; set; }
    
       
        public virtual Person who { get; set; }
    
       
        public virtual Person whom { get; set; }
    }
    
    class Person
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set;} 
        public string city { get; set; }
        public string street { get; set; }
        public string hnum { get; set; }
        public string bday { get; set; }
    
        [InverseProperty("who")]
        public virtual List<Friendship> wholist { get; set; }
    
        [InverseProperty("whom")]
        public virtual List<Friendship> whomlist { get; set; }
    }
