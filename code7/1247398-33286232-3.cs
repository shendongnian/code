    class Authenticator
    {
        static void Main(string[] args)
        {
             Authenticator au = new Authenticator();
             au.InitialValues();
             if(au.Authenticate())
                Console.WriteLine("Authenticated");
             else
                Console.WriteLine("NOT Authenticated");
             Console.WriteLine("Press Enter to end");
             Console.ReadLine();
        }
        
        // Move the boolen variable inside the method
        public bool Authenticate()
        {
            bool authenticated = false;
            Console.WriteLine("Please enter a username");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string inputPassword = Console.ReadLine();
            if (dictionary.ContainsKey(inputUsername) && dictionary[inputUsername] == inputPassword)
            {
                authenticated = true;
            }
            else
            {
                authenticated = false;
            }
            return authenticated;
        }
    }
