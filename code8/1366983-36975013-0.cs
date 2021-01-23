    public BankAccount
    {
        public Wallet Account { get; private set; } // reference to the person
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public BankAccount(Wallet account)
        {
            this.AccountNumber = GenerateAccountNumber();
            this.Balance = 0; // always zero to start with
            this.Account = account; // check to be NOT null or bank account may have no account
        }
        public void TransferMoney(decimal amount)
        {
            this.Balance += amount;
        }
        private int GenerateAccountNumber()
        {
            return new Random().Next(100000, 999999);
        }
    }
