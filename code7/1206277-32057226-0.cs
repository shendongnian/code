    string start = "F";
    string end = "gj";
    bool betweenStartAndEnd = false;
    foreach(var line in lines)
    {
        if(line == start)
            betweenStartAndEnd = true;
        if(betweenStartAndEnd || isTimeStamp(line))
            Console.WriteLine(line);
        if(line == end)
            betweenStartAndEnd = false;
    }
    public static bool isTimeStamp(string line)
    {
        return Regex.IsMatch(line, @"^\d{2}:\d{2}$");
    }
