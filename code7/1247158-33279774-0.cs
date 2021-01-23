        public bool Authenticate()
        {
            Console.WriteLine("Please enter a username");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string inputPassword = Console.ReadLine();
            return dictionary.ContainsKey(inputUsername) && dictionary[inputUsername] == inputPassword;
        }
