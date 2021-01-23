    public List<Info> Load(string file)
    {
        List<Info> info1 = new List<Info>(); 
        var contents = File.ReadLines(file)
            .Select(x=> new {item=x, index=i})
            .GroupBy(x=> x.index/2)
            .Select(x=> new Info() 
             {
                 Name = x.First().Split(':')[1],    // Name
                 Age = x.Last().Split(':')[1]      // Age
             }
            .ToList();
        
        info1.AddRange(content);
        
        return info1;
    }
