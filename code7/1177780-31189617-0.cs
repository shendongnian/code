    var list = new[]
        {
            "0509000004", "0509000005", "0509000006", "0510000003", 
            "0311100000004000", "0311100000004020",
            "063050000100", "06308C000400"
        };
    
    
    var results = new List<string>();
    
    List<Tuple<string, string>> regexes = new List<Tuple<string, string>>{
        new Tuple<string, string>( "^0(5)(?:0(\\d)|(\\d{1,2}))0*(\\d*)", "$1$2$3$4"),
        new Tuple<string, string>( "^(03111)(0+)([4]\\d{2})0$", "099$1$2$3"),
    };
    
    foreach (var number in list)
    {
        foreach (var regex in regexes)
        {
            if (Regex.IsMatch(number, regex.Item1))
            {
                results.Add(Regex.Replace(number, regex.Item1, regex.Item2));
                break;
            }
        }
    }
