    while ((line = rdr.ReadLine()) != null)
    {
        var splits = line.Split(':'); 
        info1.Add(new Info() {Name = splits[0], Age=splits[1]});                  
    }
