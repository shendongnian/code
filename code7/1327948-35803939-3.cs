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
        
        //Without the something to do (as you had it) after you enter anything it writes a 
        //line and then has nothing else to do so it closes. Have it do something like this below to fix thisd.
        Console.ReadLine(); //Now it won't close till you enter something.
    }
