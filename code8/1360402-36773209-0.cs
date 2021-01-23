    static string[] characterName()
    {
        Console.Write("Name your character: ");
        string name = Console.ReadLine();
        Console.Write("Is this correct? (Y/N): ");
        string nameConfirm = Console.ReadLine();
        return new string[]{ nameConfirm, name };
    }
