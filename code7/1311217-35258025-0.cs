    internal class MainTable
    {
        [Key]
        public int Id { get; set; }
        public virtual SubTable Sub { get; set; } // new
    }
    internal class SubTable
    {
        [Key]
        public int Id { get; set; }
        public int MainTableId { get; set; }
        [ForeignKey("MainTableId")]
        public virtual MainTable Main { get; set; } // new
    }
