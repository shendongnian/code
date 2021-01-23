    private static object getGroupedData(IEnumerable<MyPoco> rows)
    {
        var id = 1;
        var products = rows //the products, each defined by Name and Level
          .GroupBy(r => new { Name = r.Name, Level = r.Level })
          .Select(g => new
          {
              Id = id++, //create the id
              Name = g.Key.Name,
              Level = g.Key.Level,
              // select the parent and throw exception if there are more or less than one
              Parent = g.Select(r => r.Parent).Distinct().Single() 
          }).ToList();
        var results = products
          .Select(p => new //need a partial result first, containing the Global, Apac and Emea rows, if they exist
          {
              Id = p.Id,
              Name = p.Name,
              // Assuming the Level of a child is Level of parent+1
              Parent = products.FirstOrDefault(par => par.Name == p.Parent && par.Level + 1 == p.Level),
              Global = rows.FirstOrDefault(r => r.Name == p.Name && r.Level == p.Level && r.Group == "Global"),
              Apac = rows.FirstOrDefault(r => r.Name == p.Name && r.Level == p.Level && r.Group == "APAC"),
              Emea = rows.FirstOrDefault(r => r.Name == p.Name && r.Level == p.Level && r.Group == "EMEA")
          })
          .Select(x => new //create the final result
          {
              Id = x.Id,
              Name = x.Name,
              ParentId = x.Parent==null? (int?)null :x.Parent.Id,
              GlobalValue1 = x.Global == null ? (double?)null : x.Global.Value1,
              GlobalValue2 = x.Global == null ? (double?)null : x.Global.Value2,
              APACValue1 = x.Apac == null ? (double?)null : x.Apac.Value1,
              APACValue2 = x.Apac == null ? (double?)null : x.Apac.Value2,
              EMEAValue1 = x.Emea == null ? (double?)null : x.Emea.Value1,
              EMEAValue2 = x.Emea == null ? (double?)null : x.Emea.Value2
          })
          .ToArray();
        return results;
    }
