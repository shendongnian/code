    public class RICData
    {
            public string PubDate { get; set; }
            public string Settle { get; set; }
            public int ColorDer { get; set; }
    }
    
    public class NewRICData
    {
            public string Label { get; set; }
            public string Settle { get; set; }
            public int Colorder { get; set; }
    }
    
    var oldDict = new Dictionary<String, List<RICData>>();
    var newDict = oldDict.SelectMany(pair => pair.Value.Select(data => new
        {
            PubDate = data.PubDate, 
            NewRICData = new NewRICData
            {
                Label = pair.Key, 
                Settle = data.Settle, 
                ColorDer = data.ColorDer
            }
        }))
        .GroupBy(x => x.PubDate.Date)
        .ToDictionary(group => group.Key, 
                      group => group.Select(x => x.NewRICData)
                                    .OrderBy(x => x.ColorDer));
