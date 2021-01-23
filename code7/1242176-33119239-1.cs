    string[] timespans = { "-0530", "+0100" };
    foreach (string timespan in timespans)
    {
        bool isNegative = timespan.StartsWith("-");
        string format = isNegative ? "\\-hhmm" : "\\+hhmm";
        TimeSpanStyles tss = isNegative ? TimeSpanStyles.AssumeNegative : TimeSpanStyles.None;
        TimeSpan ts;
        if (TimeSpan.TryParseExact(timespan, format, null, tss, out ts))
        {
            Console.WriteLine("{0} successfully parsed to: {1}", timespan, ts);
        }
        else
        {
            Console.WriteLine("Could not be parsed: {0}", timespan);
        }
    }
