    public class Review
    {
        public int Id { get; set; }
    
        [Required]
        [InverseProperty("Reviews")]
        public Employee Employee { get; set; }
    
        [Required]
        public Employee Manager { get; set; }
     }
    
    public class Employee
        {
            public int Id { get; set; }
    
            [InverseProperty("Employee")]
            public ICollection<Review> Reviews { get; set; }
        }
