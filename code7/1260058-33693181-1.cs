    string line = Console.ReadLine();
    DateTime dt;
    bool validDate = DateTime.TryParseExact(line,"dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo,DateTimeStyles.None, out dt);
    if(validDate)
        Console.WriteLine(dt.ToLongDateString()); // now correctly initialized 
