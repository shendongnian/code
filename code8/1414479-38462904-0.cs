    Console.WriteLine("Hello Jake. Security check: Please type the security code for a database.");
    // This will read all the characters until the user presses Enter
    string password = Console.ReadLine();
    switch (password)
    {
        case "POKEMON":
        {
            // Load some database
            break;
        }
        case "PASSWORD":
        {
            // Load another database
            break;
        }
        default:
        {
            Console.WriteLine("Invalid password");
        }
    }
