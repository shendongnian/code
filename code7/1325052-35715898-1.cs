    // this is the data model
    public class Sensor
    {
        public int Id { get; set; }
    
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
    // this is the data model
    public class SensorViewModel
    {
        public int Id { get; set; }
    
        [Required]
        [StringLength(8)]
        public string Name { get; set; }
    }
