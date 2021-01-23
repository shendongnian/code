    public class Regions : EntityData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        [NotMapped]
        public new DateTimeOffset? CreatedAt { get; set; }
        [NotMapped]
        public new DateTimeOffset? UpdatedAt { get; set; }
        [NotMapped]
        public new byte[] Version { get; set; }
    }
