    FileStream fstream = new FileStream("@path", FileMode.Open,FileAccess.Read, FileShare.ReadWrite);
    StreamReader sreader = new StreamReader(fstream);
    List<string> lines = new List<string>();
    string line;
    while((line = sreader.ReadeLine()) != null)
        lines.Add(line);
    //do something with the lines
    //if you need all lines at once,
    string allLines = sreader.ReadToEnd();
