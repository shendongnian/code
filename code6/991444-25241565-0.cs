    var file1 = new HashSet<string>(File.ReadAllLines(path1));
    string line;
    var file2 = new System.IO.StreamReader(path2);
    Dictionary<string, string> links = new Dictionary<string, string>();
    while ((line = file2.ReadLine()) != null)
    {
        string nextLine;
        if (file1.Contains(line) && (nextLine = file2.ReadLine()) != null)
            links[line] = nextLine;
    }
