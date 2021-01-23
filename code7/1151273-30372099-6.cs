    public static void RunProgram()
    {
     Console.WriteLine("Please type in character");
     input = Console.ReadKey().KeyChar;
     Console.WriteLine("You typed in " + input + ". This results in: " + ChangeInput(input));
    }
