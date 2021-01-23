    public class CarColor
    {
        [Key]
        public int CarColorId { get; set; }
    
        [MinLength(3)]
        public string Name { get; set; }
    
        [Required]
        public string ColorCode { get; set; }
    }
    
    public class Car
    {
        [Key]
        public int CarId { get; set; }
    
        [MinLength(2)]
        public string Name { get; set; }
    
        [Required]
        public DateTime YearOfConstruction { get; set; }
    
        [Required]
        public CarColor Color { get; set; }
    }
