    // parse "1.CSV"
    List<string[]> lst1 = File.ReadAllLines(@"C:\Temp\1.csv").
                Select(line => line.Split(';')).
                ToList();
    // parse "2.CSV"
    List<string[]> lst2 = File.ReadAllLines(@"C:\Temp\2.csv").
                Select(line => line.Split(';')).
                ToList();
    // extracting once speeds things up in the next step
    //  and leaves open the possibility of iterating in a method
    List<List<string>> tgts = new List<List<string>>();
    tgts.Add(lst1.Select(z => z[1]).Distinct().ToList());
    tgts.Add(lst1.Select(z => z[2]).Distinct().ToList());
    var tmpLst = lst2.Where(x => !tgts[0].Contains(x[1]) ||
                    !tgts[1].Contains(x[2])).
                    ToList();
