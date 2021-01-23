    public class Matrix_Element
    {
        [Key, Column(Order = 0)]
        public int RowID { get; set; }
        [Key, Column(Order = 1)]
        public int ColID { get; set; }
        public int? cellValue { get; set; }
        public string R { get; set; }
    }
