    public class Muppet
    {
        [Required]
        [StringLength(50)]
        public string Name {get; set;}  
        
        public Color Color {get; set; }
    
        [Range(0,100)]
        public int Scaryness {get; set; }
    
        [MyCustomEmailValidator]
        public string Email {get;set; }
    }
