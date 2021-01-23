    public static void Main(params string[] args)
    {
        string username = "";
        string pass = "";
        string confirmPass = "";
        Console.Write("Enter username: ");
        username = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter your password: ");
        pass = ReadPassword(); // changed to function call
        Console.WriteLine("");
        Console.WriteLine("Confirm your password: ");
        int retryCount = 3;
        string finalPass = "";
        confirmPass = ReadPassword(); // changed to function call
        do
        {
            if (confirmPass != pass) // <==== this is performed before the "else"
            {
                Console.WriteLine("Re-enter Password: (" + retryCount + " tries remaining)");
                confirmPass = ReadPassword(); // changed to function call
                retryCount--;
            }
            else if (confirmPass == pass) // <==== "else": bug
            {
                // Bug: it will only get here, if the confirmed password 
                // was entered correctly the first time
                Console.WriteLine("Enter password to log in :");
                finalPass = Console.ReadLine();
                if (finalPass == pass)
                {
                    Console.WriteLine("Login Successful. Welcome " + username + "!");
                    Console.WriteLine();
                    Console.WriteLine("Test Successful. Press Enter to quit.");
                }
                // else <==== now what?
            }
            if (retryCount == 0)
            {
                Console.WriteLine("Exceeded number of tries!!");
                Console.ReadLine();
            }
        } while (confirmPass != pass && retryCount != 0);
    }
