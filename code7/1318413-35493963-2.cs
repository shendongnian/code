    public class First {
        [Key]
        public int ProdId { get; set; }
        public string Supplier { get; set; }
        public string TableName { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
