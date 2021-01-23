    public class Expense
    {
        public decimal Food{ get; set; }
        public decimal Clothing{ get; set; }
        public decimal Medical{ get; set; }
        public decimal TotalExpense { get { return Food+Clothing+Medical; } }
    }
