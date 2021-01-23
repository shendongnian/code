    public sealed class Record : TrackedEntity
    {
        [Key]
        public int RecordID { get; set; }
    
        [MaxLength(64)]
        public string Name { get; set; }
        public int RecordTypeID { get; set; }
        [ForeignKey("RecordTypeID")]
        public virtual RecordType { get; set; }
    }
