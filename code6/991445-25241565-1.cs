    var links = new Dictionary<string, string>();
    var file1 = new HashSet<string>(File.ReadLines(path1));
    var file2 = new System.IO.StreamReader(path2);
    string line;
    while ((line = file2.ReadLine()) != null)
    {
        string nextLine;
        if (file1.Contains(line) && (nextLine = file2.ReadLine()) != null)
            links[line] = nextLine;
    }
