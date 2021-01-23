    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public City City { get; set; }
    }
