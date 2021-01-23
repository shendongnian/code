         [Table(Name = "Labels")]
    public class Labels
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated=true)]
        public int Id { get; set; }
         [Column(Name = "Type")]
        public string Type { get; set; }
         [Column(Name = "Label")]
        public string Label { get; set; }
         [Column(Name = "Active", CanBeNull=true)]
        public Nullable<bool> Active { get; set; }
         [Column(Name = "Operation")]
        public string Operation { get; set; }
         [Column(Name = "Value")]
        public string Value { get; set; }
    }
