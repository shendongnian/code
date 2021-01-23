    class Atm
    {
        public List<Account> Accounts { get; set; }
        public Atm()
        {
            Accounts = new List<Account>();
        }
        public void CreateAccount()
        {
            var account = new Account();
            // Get details from user here:
            ...
            account.Balance = 0.0;
            account.Id = Accounts.Count + 1;
            Accounts.Add(account);
        }
        public void Deposit()
        {
            int accountId;
            // Get input from the user here:
            // --------------------------------
            // 1. Check that the account exists
            // 2. Deposit into the account.
            ...
        }
