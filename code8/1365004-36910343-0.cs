    class Account
    {
        decimal balance;
        private Object thisLock = new Object();
    
        public void Withdraw(decimal amount)
        {
            lock (thisLock)
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient funds");
                }
                balance -= amount;
            }
        }
    }
