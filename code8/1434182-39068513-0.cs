    class Filter
    { 
            public List<BsonValue> Vendors { get; set; }
    }
    
    ...
    
    var list = parts.Where(d => filter.Vendors.Contains(d["Vendor"]));
    foreach (var document in list)
    {
        Console.WriteLine(document["Name"]);
    }
