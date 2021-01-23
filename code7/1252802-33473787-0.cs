    DateTime d;
    if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
    {
        Console.WriteLine("An invalid date format was supplied.");
    }
