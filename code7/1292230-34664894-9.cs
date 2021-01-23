	public static class TransactionUtils
	{
		public static IEnumerable<KeyValuePair<Transaction, decimal>> GetCreditInfo(this IEnumerable<Transaction> accountTransactions)
		{
			decimal credit = 0;
			return from t in accountTransactions
				   orderby t.Date, t.ID
				   select new KeyValuePair<Transaction, decimal>(t, credit += t.IsCredit ? t.Value : -t.Value);
		}
	}
