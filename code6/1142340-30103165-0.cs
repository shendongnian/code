    DateTime parsedDateTime;
    string Duration = null;
    if (!DateTime.TryParseExact("1899-12-30 01:30:00", //or rw["Taught Periods Distinct as duration"].ToString();
        "yyyy-MM-dd HH:mm:ss",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out parsedDateTime))
    {
        Console.WriteLine("Invalid date");
    }
    else
    {
        Duration = parsedDateTime.ToString("HH:mm", CultureInfo.InvariantCulture);
    }
