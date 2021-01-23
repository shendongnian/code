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
    
    var newDict = dict.SelectMany(pair => pair.Value.Select(data => new
        {
            Date = data.PubDate, 
            NewRICData = new NewRICData
            {
                Label = pair.Key, 
                Settle = data.Settle, 
                ColorDer = data.ColorDer
            }
        }))
        .GroupBy(x => x.Date)
        .ToDictionary(group => group.Key, 
                        group => group.Select(x => x.NewRICData)
                                    .OrderBy(x => x.ColorDer));
