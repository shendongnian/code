    List<string> nameList = new ArrayList<string>();
    foreach(string line in lines)
        string[] namesLine = line.Split(',');
        foreach(string name in namesLine)
            nameList.Add(name);
