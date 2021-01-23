    [Table(Name = "TestTable")]
    public class TestTable
    {
        [Column(IsPrimaryKey = true)]
        public int? id { get; set; }
        [Column]
        public string title { get; set; }
    }
