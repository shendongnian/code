    public class Car
    {        
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        [Key, Column(Order = 1)]
        public int ChassisSerial { get; set; }
    
        [ForeignKey("Person"), Column(Order = 0)]
        public int PersonID { get; set; }
        [ForeignKey("Person"), Column(Order = 1)]
        public int PersonSsn { get; set; }
    
        public virtual Person Person { get; set; }
    }
