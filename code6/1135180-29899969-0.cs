    string path = @"C:\Users\jzhu\Desktop\test1.txt";
    List<string> lines = new List<string>(File.ReadAllLines(path));
    for (int i = 0; i < lines.Count; i++)
    {
         lines[i] = lines[i].Replace("T1.data1 < 1901, AS", "T2.data1 AS"));
    }
    File.ReadAllLines(path, lines);
