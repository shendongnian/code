    private string nameCheck(string n)
    {
        if (String.IsNullOrEmpty(n))
        {
            Console.WriteLine("Geben Sie einen Namen ein")
            n = Console.ReadLine();
        }
        return n;
    }
