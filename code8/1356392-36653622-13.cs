    public static Dictionary<string,string> ItemEntries(string LocationAndCategory)
    {
        return File.ReadAllLines(fileOfLocations).Select(l=> new {Line=l, Columns=l.Split(',')})
                                                 .Where(e=>e.Columns[0]+" "+e.Columns[1]==LocationAndCategory)
                                                 .ToDictionary(e=>e.Columns[0]+e.Columns[1]+e.Columns[2],e=>e.Line);
    }
