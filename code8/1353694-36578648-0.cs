    IDictionary<string, string> trace = new Dictionary<string, IList<string>>();
    
    trace.Add("date", new List<string>())
    trace.Add("type", new List<string>())
    
    var obj = JsonConvert.DeserializeObject<List<RootObject>>(responseText);
    
    foreach (var item in obj)
    {
       trace["date"].Add(item.trace.details.date)
       trace["type"].Add(item.trace.details.type)
    }
