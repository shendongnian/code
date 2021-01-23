    public static void Main(string[] args)
    {
        //Writing to the screen
        Console.WriteLine("Welcome to the Ceaser Cipher Shift Program");
        Console.WriteLine("Would You Like to Decrypt a File (y for yes/n for no)");
        switch (Console.ReadKey(true).Key)
        {
            // if the user types "y", activate the decryption method
            case ConsoleKey.Y:
                decryption();
                break;
            // if the user types in "n", write "Goodbye" and close the program
            case ConsoleKey.N:
            default:
                Console.WriteLine("Goodbye");
                Environment.Exit(0);
                break;
        }
    }
