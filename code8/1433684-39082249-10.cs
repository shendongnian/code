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
    
    rezLst = lst2.Where(x => !ContainsElementAt(lst1, x, 1) ||
                            !ContainsElementAt(lst1, x, 2)).
                            Select(q => string.Join(";", q)).
                            ToList();
    // show results
    foreach (string s in rezLst)
    {
        dgv2.Rows.Add(s.Split(';'));
    }
