    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual Car Car{get;set;}
    }
    
    public class Car
    {
        [Key,ForeignKey("Thing")]
        public int ThingId { get; set; }
        //other properties
    
        public virtual Thing Thing{get;set;}
    }
