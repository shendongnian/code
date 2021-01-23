    foreach (var item in db.Pos.GroupBy(a=> a.Pla).Select(p=> new     
    {
      Pla = p.Key, 
      Pdv = p.Select(a => a.Pdv).FirstOrDefault(),
      Nombre = p.Select(a => a.Description).FirstOrDefault(), 
      Rid = p.Select(a => a.Rid).FirstOrDefault(), 
      Quantity = p.Sum(q=>q.Cantidad), 
      Total= p.Sum(x=>x.Total)
    }))
    
    {
      listItemPopu.Add(item.ToString());
    }
