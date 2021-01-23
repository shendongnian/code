    public class CarModel
    {    
        [MinLength(2)]
        public string Name { get; set; }
        
        [Required]
        public DateTime YearOfConstruction { get; set; }
        
        [Required]
        public int ColorId { get; set; }    
    }
