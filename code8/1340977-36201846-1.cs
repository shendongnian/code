    using System.ComponentModel.DataAnnotations;
    
    public class Dog
    {
        [Key]
        public long Id { get; set; }
        public int? Age { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
    } 
