	public enum TransactionType { Credit, Debit }
	public class Transaction
	{
		public int ID { get; set; }
		public DateTime Date { get; set; }
		public decimal Value { get; set; }
		public TransactionType Type { get; set; }
		public int Account { get; set; }
	}
