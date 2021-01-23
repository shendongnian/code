    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int StateId { get; set; }
        [JsonIgnore]
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
