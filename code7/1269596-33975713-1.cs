    protected void login(string command, string param1, string param2) // string command "login" string username, string password
    {
        if (command == "login")
        {
            var logins = File.ReadAllLines(@"C:\\Files\\accounts.txt");
            if (logins.Any(l => l == string.Format("{0} {1}", param1, param2)))
                Console.WriteLine("login {0} successful", param1);
            else
            {
                //log audit details
                Console.WriteLine("invaild username/password");
            }
        }
    }
