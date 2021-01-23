    static string name;
    static static void Main(string[] args)
    {
        //intro
    
        System.Console.WriteLine("Welcome to TextAdventure!");
        System.Console.WriteLine("This is an entry level program made by JussaPeak");
        System.Console.WriteLine("commands will be noted in the text by (). enter an applicable choice.");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("Please enter your name:");
        name = Convert.ToString(Console.ReadLine());
        System.Console.WriteLine("  ");
        System.Console.WriteLine("Hello, {0}. You are about to embark on a lackluster journey of my first text adventure. i hope you enjoy!", name);
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
    
        StartingArea();
    }
