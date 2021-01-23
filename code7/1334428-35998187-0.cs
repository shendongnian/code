    public class ModelDTO
    {
        // The name is required => make sure that your DTO
        // respects this requirement as well
        [Required]
        public string Name { get; set; }
    }
