    string path = @"c:\users\povermyer\documents\visual studio 2013\Projects\DanProject\PNRS\PNRS.log";
    string[] groupNames = new[] { "A", "B" };
    string[] lines = System.IO.File.ReadAllLines(path);
    int count = lines.Length
    Dictionary<string, List<string>> groups = SeparateGroups(lines, groupNames);
