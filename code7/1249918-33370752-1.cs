    string[] lines = new string[2] { "016584824684000000000000000+", "045787544574000000000000000+" };
    List<string> first = new List<string>();
    List<string> second = new List<string>();
    foreach (string line in lines)
    { 
        first.Add(line.Substring(0, 5));
        second.Add(line.Substring(6, 6));
    }
