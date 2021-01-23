    static void Main(string[] args)
    {
        Console.WriteLine("Type a number, any number!");
        ConsoleKeyInfo keyinfo = Console.ReadKey();
        PrintCalculation10times();
        if (char.IsLetter(keyinfo.KeyChar)) 
        {
            Console.WriteLine("That is not a number, try again!");
        }
        else
        {
            Console.WriteLine("Did you type {0}",keyinfo.KeyChar.ToString());
        }
        
        Console.ReadLine(); //Now it won't close till you enter something.
    }
