    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? DriverId { get; set; }
        
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
    }
    
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
