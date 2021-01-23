    [Table("Settings")]
    public class ServiceSettings
    {
        [Key]
        public int Id { get; set; }  // Created ID field
        public string Name { get; set; }
        public string BrandCode { get; set; }  
        public string Value { get; set; }
    
    }
