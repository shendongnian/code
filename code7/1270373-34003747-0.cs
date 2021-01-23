    var logins = File.ReadAllLines(@"C:\\Files\\accounts.txt");
    if (command == "login")
    {
        if (IsUserLoggedIn) //check whether someone is logged in
        {
            Console.WriteLine("Login Failed: simultaneous login not permitted");
            string path2 = "C:\\Files\\audit.txt";
            using (StreamWriter sw2 = File.AppendText(path2))
            {
                sw2.WriteLine("Login Failed: simultaneous login not permitted");
            }
        }
        else if (logins.Any(l => l == string.Format("{0} {1}", param1, param2)))
        {
           IsUserLoggedIn = true; // set the flag so that you know someone has logged in
           Console.WriteLine("Login {0} ", param1);
           string path1 = "C:\\Files\\audit.txt";
           using (StreamWriter sw1 = File.AppendText(path1))
           {
               sw1.WriteLine("User " + param1 + " logged in");
           }
        }
        else
        {
            Console.WriteLine("Login Failed: Invaild username or password");
        }
    }
