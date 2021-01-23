    public sealed class Record_History : TrackedEntity
    {
        [Key]
        public int ID { get; set; }
        public int RecordID { get; set; }
    
        [MaxLength(64)]
        public string Name { get; set; }
        public int RecordTypeID { get; set; }
    }
