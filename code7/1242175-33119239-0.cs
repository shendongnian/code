    string[] timespans = { "-0530", "+0100" };
    foreach (string timespan in timespans)
    {
        bool isNegative = timespan.StartsWith("-");
        string format = isNegative ? "\\-hhmm" : "\\+hhmm";
        TimeSpan ts;
        if (TimeSpan.TryParseExact(timespan, format, null, out ts))
        {
            if (isNegative) 
               ts = ts.Negate();
            Console.WriteLine("{0} successfully parsed to: {1}", timespan, ts);
        }
        else
        {
            Console.WriteLine("Could not be parsed: {0}", timespan);
        }
    }
