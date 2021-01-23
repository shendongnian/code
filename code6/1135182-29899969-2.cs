    string path = @"C:\Users\jzhu\Desktop\test1.txt";
    List<string> lines = new List<string>(File.ReadAllLines(path));
    for (int i = 0; i < lines.Count; i++)
    {
         lines[i] = Regex.Replace(lines[i], @"T1\.([^ ]*) < 1901, AS", "T2.$1 AS");
    }
    File.WriteAllLines(path, lines);
