    public class ValuesObject
    {
        [Required]
        public string Name { get; set; }
    
        [Range(10, 100, ErrorMessage = "This isn't right")]
        public int Age { get; set; }
    }
