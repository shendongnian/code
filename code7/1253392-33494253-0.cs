    var input = @"A574A02211     S193FDRA3     20141023S17337     WAN HAI 307
    A024A13787     S1023F                S1023F     WAN HAI 316
    A574A02181     S187FDRA3     20141024S17337     WAN HAI 307";
        
    var positionsToSplitOn = new int [] { 0, 15, 29, 37, 48 };
        
    var lines = new List<List<string>>();
    foreach (var line in input.Split('\n'))
    {
        var columnValues = new List<string>();
        for (int i = 0; i < positionsToSplitOn.Length - 1; ++i)
        {
            columnValues.Add(line.Substring(positionsToSplitOn[i], positionsToSplitOn[i + 1] - positionsToSplitOn[i]).Trim());
        }
        columnValues.Add(line.Substring(positionsToSplitOn[positionsToSplitOn.Length - 1]).Trim());
        lines.Add(columnValues);
    }
