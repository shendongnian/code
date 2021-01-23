    static string characterName(ref string name)
    {
        Console.Write("Name your character: ");
        string name = Console.ReadLine();
        Console.Write("Is this correct? (Y/N): ");
        string nameConfirm = Console.ReadLine();
        return nameConfirm;
    }
