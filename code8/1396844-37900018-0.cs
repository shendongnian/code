    TimeSpan _time;
    string input = "08:55 PM";
    string[] fmts = new string[] {@"hh\:mm\ \A\M", @"hh\:mm\ \P\M"};
    if(TimeSpan.TryParseExact(input, fmts, CultureInfo.InvariantCulture, out _time))
    {
        if(input.EndsWith("PM"))
           _time = _time.Add(new TimeSpan(12,0,0));
        Console.WriteLine(_time.ToString());        
    }
