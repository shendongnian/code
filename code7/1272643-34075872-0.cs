    string input = "t1126".Replace("t", "");
    string pattern = "hhmm";
    DateTime dt;
    
    DateTime.TryParseExact(input, pattern, null, DateTimeStyles.None, out dt);
    Console.WriteLine(dt.ToString("h:m tt"));
