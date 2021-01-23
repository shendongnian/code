	public class Account
	{
		private decimal _balance = 0m;
		private object _transactionLock = new object();
		private object _saveLock = new object();
		
		public void Deposit(decimal amount)
		{
			lock (_transactionLock)
			{
				_balance += amount;
			}
		}
	
		public void Withdraw(decimal amount)
		{
			lock (_transactionLock)
			{
				_balance -= amount;
			}
		}
		
		public void Save()
		{
			lock (_saveLock)
			{
				File.WriteAllText(@"C:\Balance.txt", _balance.ToString());
			}
		}
	}
