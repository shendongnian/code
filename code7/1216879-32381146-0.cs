    string line = Console.ReadLine();
    DateTime dt;
    while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
    {
        Console.WriteLine("Invalid date, please retry");
        line = Console.ReadLine();
    }
