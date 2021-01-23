    class authenticator
    {
        private Dictionary<string, string> Credentials = new Dictionary<string, string>();
        public authenticator()
        {
            //username and password
            Credentials.Add("bob", "password1");
            Credentials.Add("alice", "password2");
        }
        public bool ValidateCredentials(string username, string password)
        {
            return Credentials.Any(entry => entry.Key == username && entry.Value == password);
        }
    }
    class Program
    {
        static private authenticator auth = new authenticator();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username : ");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            var password = Console.ReadLine();
            var isvalid = auth.ValidateCredentials(username, password);
            Console.WriteLine("Your are{0} authenticated!", isvalid ? string.Empty : " NOT");
            Console.ReadLine();
        }
    }
