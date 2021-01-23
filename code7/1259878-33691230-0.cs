    public class Material
    {
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
        public string Producer { get; set; }
    
        [Required]
        public int CompanyId { get; set; } // THIS IS NEW!!!
        public virtual Company Company { get; set; }
    
        public Material()
        {
        }
    }
