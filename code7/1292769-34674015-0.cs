    List<string> lineList = new List<string>();
    while ((line = file.ReadLine()) != null)
    {
        Console.WriteLine(line);
        lineList.add(line);
        counter++;
    }
    for(int i = 2; i < lineList.Count; i++) {
        string[] split = lineList[i].Split(new char[] {' '});
        Console.WriteLine(string.Format("{0} {1}", split[0], split[2]));
    }
