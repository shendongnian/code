    // several others were not as fast
    List<List<string>> tgts = new List<List<string>>();
    List<string[]> tmp = new List<string[]>();
    // parse "1.CSV"
    foreach (string s in txtA)
    {
        tmp.Add(s.Split(';'));
    }
    
    // isolate the distinct elements 
    tgts.Add(tmp.Select(z => z[1]).Distinct().ToList());
    tgts.Add(tmp.Select(z => z[2]).Distinct().ToList());
    // parse "2.CSV"
    foreach (string s in txtB)
    {
        lst2.Add(s.Split(';'));
    }
    
    // just use Contains to get the unique ones:
    rezLst = lst2.Where(x => !tgts[0].Contains(x[1]) ||
                    !tgts[1].Contains(x[2])).
                    Select(q => string.Join(";", q)).
                    ToList();
    // show results
    foreach (string s in rezLst)
    {
        dgv2.Rows.Add(s.Split(';'));
    }
