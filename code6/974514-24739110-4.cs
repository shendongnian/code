    if (!string.IsNullOrEmpty(ownRG))
    {
        var maclist = new CommaSeparatedStringEnumerable(str);
        var temp = powlist.Where(a => maclist.Contains(a.Machine));
        foreach (var p in temp)
        {
            p.ReportingGroup = ownRG;
        }
    } 
