    // #1 Read CSV File
    string[] CSVDump = File.ReadAllLines(@"c:\temp.csv");
    // #2 Split Data
    List<List<string>> CSV = CSVDump.Select(x => x.Split(';').ToList()).ToList();
                        
    //#3 Update Data
    for (int i = 0; i < CSV.Count; i++)
    {
        CSV[i].Insert(0, i == 0 ? "Headername" : "Filename");
    }
    //#4 Write CSV File
    File.WriteAllLines(@"c:\temp2.csv", CSV.Select(x => string.Join(";", x)));
