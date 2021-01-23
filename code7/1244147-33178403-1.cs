    public class Resource
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResourceId { get; set; }        
    }
    public class Profile
    {
        [Key]
        [ForeignKey("Resource")]
        public Guid ProfileId { get; set; }
        public Resource Resource { get; set; }
        public string Name { get; set; }
        public Profile()
        {
            Resource = new Resource();
        }
    }
