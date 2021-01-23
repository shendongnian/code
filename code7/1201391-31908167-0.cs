    public class SharedDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public DateTime Modified { get; set; }
        [ForeignKey("ModifiedById")]
        public virtual ApplicationUser ModifiedBy { get; set; }
        public int ModifiedById { get; set; }
        public string ContentType { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        public double Version { get; set; }
    }
