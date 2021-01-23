    Settle settle = new Settle { Pixels = 1.5, Time = 8, Timeout = 40 };
    var parameterList = new List<string>()
    {
        ditherAmount.ToString(),
        ditherRaOnly.ToString(),
        string.Join(",", settle.Pixels, settle.Time, settle.Timeout)
    };
    Dither dither = new Dither { Method = "dither", Parameters = parameterList, Id = 42 };
    string temp = dither.ToJSON();
