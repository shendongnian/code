    public class Account
    {
        public readonly int ID;
        public string Username;
        public string Password;
        public decimal Balance;
        public Account(int id, string username, string password)
        {
            ID = id;
            Username = username;
            Password = password;
        }
    }
