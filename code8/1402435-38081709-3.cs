    DateTime dt;
    bool res = DateTime.TryParseExact("02/03/2001", "MM/dd/yyyy", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None, out dt);
    Console.WriteLine(dt);
    // will output Feb 3, 2001, but a user in GB would probably intend Mar 3, 2001
    bool res = DateTime.TryParseExact("02/03/2001", "d", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None, out dt);
    Console.WriteLine(dt);
    // will output Mar 3, 2001, but might be too restrictive for what you want?
    res = DateTime.TryParse("02/03/2001", CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None, out dt);
    Console.WriteLine(dt);
    // will output Mar 2, 2001, but goes back to your original problem
