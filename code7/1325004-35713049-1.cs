    foreach (var item in db.Pos.GroupBy(a=> a.Pla).Select(p=> new     
    {
      Pla = p.Key, 
      Pdv = p.Key.Pdv,
      Nombre = p.Key.Description, 
      Rid = p.Key.Rid, 
      Quantity = p.Sum(q=>q.Cantidad), 
      Total= p.Sum(x=>x.Total)
    }))
    
    {
      listItemPopu.Add(item.ToString());
    }
