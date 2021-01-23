    class Program
    {
        static void Main()
        {
            var atm = new Atm();
            while (true)
            {
                int option;
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine();
                Console.Write("Please make a selection: ");
                var input = int.TryParse(Console.ReadLine(), out option);
                Console.WriteLine("-----------------");
                switch (option)
                {
                    case 1:
                        atm.CreateAccount();
                        break;
                    case 2:
                        atm.Deposit();
                        break;
                }
            }
        }
    }
    class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public double Balance { get; set; }
    }
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
            Console.WriteLine("Create a new account!");
            Console.WriteLine();
            Console.Write("Enter first name: ");
            account.FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            account.LastName = Console.ReadLine();
            Console.Write("Enter date of birth: ");
            account.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter phone number: ");
            account.PhoneNumber = Console.ReadLine();
            account.Balance = 0.0;
            account.Id = Accounts.Count + 1;
            Accounts.Add(account);
        }
        public void Deposit()
        {
            int accountId;
            Console.Write("Enter your account number: ");
            int.TryParse(Console.ReadLine(), out accountId);
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                double amount;
                Console.Write("Enter amount to deposit: ");
                double.TryParse(Console.ReadLine(), out amount);
                account.Balance += amount;
                Console.Write("Your new balance is {0}", account.Balance);
            }
            else
            {
                Console.WriteLine("That account does not exist!");
            }
        }
    }
