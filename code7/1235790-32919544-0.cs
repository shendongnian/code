    HashSet<string> uniqueLines = new HashSet<string>();
    foreach(string line in File.ReadLines("F1.txt"))
    {
        if (uniqueLines.Contains(line))
            continue;
        string[] tokens = line.Split(',');
        string reversedLine = string.Join(",", tokens.Reverse());
        if (uniqueLines.Contains(reversedLine))
            continue;
        uniqueLines.Add(line);
    }
    File.WriteAllLines("F2.txt", uniqueLines);
