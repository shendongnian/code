    public static void Main(string[] args)
    {
        string username = "";
        string pass = "";
        string confirmPass = "";
        Console.Write("Enter username: ");
        username = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter your password: ");
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            // Backspace Should Not Work
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
            {
                pass = pass.Substring(0, (pass.Length - 1));
                Console.Write("\b \b");
            }
            // Stops Receving Keys Once Enter is Pressed
        } while (key.Key != ConsoleKey.Enter);
        Console.WriteLine("");
        Console.WriteLine("Confirm your password: ");
        ConsoleKeyInfo confirmKey;
        int retryCount = 3;
        string finalPass = "";
        do
        {
            confirmKey = Console.ReadKey(true);
            // Backspace Should Not Work
            if (confirmKey.Key != ConsoleKey.Backspace && confirmKey.Key != ConsoleKey.Enter)
            {
                confirmPass += confirmKey.KeyChar;
                Console.Write("*");
            }
            else if (confirmKey.Key == ConsoleKey.Backspace && pass.Length > 0)
            {
                confirmPass = confirmPass.Substring(0, (confirmPass.Length - 1));
                Console.Write("\b \b");
            }
            // Stops Receving Keys Once Enter is Pressed
        } while ((confirmKey.Key != ConsoleKey.Enter));
            
        do
        {
            if (confirmPass != pass)
            {
                confirmPass = "";
                Console.WriteLine("Re-enter Password: (" + retryCount + " tries remaining)");
                do
                {
                    confirmKey = Console.ReadKey(true);
                    // Backspace Should Not Work
                    if (confirmKey.Key != ConsoleKey.Backspace && confirmKey.Key != ConsoleKey.Enter)
                    {
                        confirmPass += confirmKey.KeyChar;
                        Console.Write("*");
                    }
                    else if (confirmKey.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        confirmPass = confirmPass.Substring(0, (confirmPass.Length - 1));
                        Console.Write("\b \b");
                    }
                    // Stops Receving Keys Once Enter is Pressed
                } while ((confirmKey.Key != ConsoleKey.Enter));
                retryCount--;
            }
            else if (confirmPass == pass)
            {
                Console.WriteLine("Enter password to log in :");
                finalPass = Console.ReadLine();
                if (finalPass == pass)
                {
                    Console.WriteLine("Login Successful. Welcome " + username + "!");
                    Console.WriteLine();
                    Console.WriteLine("Test Successful. Press Enter to quit.");
                    Console.ReadLine();
                    break;
                }
            }
            if (retryCount == 0)
            {
                Console.WriteLine("Exceeded number of tries!!");
                Console.ReadLine();
            }
        } while (retryCount != 0);
    }
