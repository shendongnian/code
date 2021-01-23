    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("City_Id")]
        public City City { get; set; }
        [Required]
        public int City_Id { get; set; }
    }
