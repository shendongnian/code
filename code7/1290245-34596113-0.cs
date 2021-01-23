    public class Invoice
    {
        public int Id { get; set; }
        public int MorningExpenseId { get; set; }
        public int EveningExpenseId { get; set; }
        public virtual Expense MorningExpense { get; set; }
        public virtual Expense EveningExpense { get; set; }
    }
    public class Expense
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
