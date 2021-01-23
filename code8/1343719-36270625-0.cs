    var id=1;
    var rows=dt.Rows.OfType<DataRow>();
    var products=rows
      .GroupBy(r=>r["Name"])
      .Select(g=>new {
         Id=id++,
         Name=g.Key,
         Parent=g.Distinct(r=>r["Parent"]).Single()
       });
    var results=products
      .Select(p=>new {
        Id=p.Id,
        Name=p.Name,
        ParentId=products.FirstOrDefault(par=>par.Name==p.Parent)?.Id,
        Global=rows.FirstOrDefault(r=>r["Name"]==p.Name&&r["Group"]=="Global"),
        Apac=rows.FirstOrDefault(r=>r["Name"]==p.Name&&r["Group"]=="APAC"),
        Emea=rows.FirstOrDefault(r=>r["Name"]==p.Name&&r["Group"]=="EMEA")
      })
      .Select(x=>new {
        Id=x.Id,
        Name=x.Name,
        ParentId=x.ParentId,
        GlobalValue1=x.Global?.Value1,
        GlobalValue2=x.Global?.Value2,
        APACValue1=x.Apac?.Value1,
        APACValue2=x.Apac?.Value2,
        EMEAValue1=x.Emea?.Value1,
        EMEAValue2=x.Emea?.Value2
      })
      .ToArray();
