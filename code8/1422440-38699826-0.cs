    private void nameCheck(ref string n)
    {
        if (n == "")
        {
            Console.WriteLine("Geben Sie einen Namen ein");
            n = Console.ReadLine();
        }
    }
