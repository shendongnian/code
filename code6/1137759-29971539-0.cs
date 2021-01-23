    public class Car
    {
        public int Id { get; set; }
        public virtual Driver { get; set; }
    }
    
    public class Driver
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car { get; set; }
    }
