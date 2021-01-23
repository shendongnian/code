    public class Profile
    {
        [Key, ForeignKey("Resource"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ProfileId { get; set; }
        public Resource Resource { get; set; }
        public string Name { get; set; }
    }
