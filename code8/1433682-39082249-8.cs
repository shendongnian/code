    // parse "1.CSV"
    foreach (string s in txtA)
    {
        lst1.Add(s.Split(';'));
    }
    // or
    //var lstS = File.ReadAllLines(@"C:\Temp\1.csv").
    //        Select(line => line.Split(';').ToArray()).ToList();
    // parse "2.CSV"
    foreach (string s in txtB)
    {
        lst2.Add(s.Split(';'));
    }
    
    rezLst = lst2.Where( x => !MySequenceContains(lst1, x)).
                Select( q => string.Join(";", q)).
                ToList();
    
    // show results
    foreach (string s in rezLst)
        Console.WriteLine( s );
