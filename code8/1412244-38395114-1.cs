    struct DataItem
    {
        string Series{get;set;}
        int ID{get;set;}
        int[] Cord{get;set;}
    }
    string seriesSeperator = <Seperator string>
    string colSeperator = <Seperator string>
    List<DataItem> items
    foreach(string series in OriginalString.Split(seriesSeperator)
    {
        var rows = serive.Split(Environment.Newline);
        var name = series[0];
        for(int i = 1;i<series.Lenth;i++)
        {
            var col = row.Split(colSeperator );
            items.Add( new DataIten
            {
                Series = name,
                ID = int.Parse(col[0]),
                cord = col[1].Split(",").Select(c=>int.Parse(c)).ToArray()
            });
        }
    }
