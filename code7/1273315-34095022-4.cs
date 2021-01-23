    IQueryable<SomeEntity> query=(new SomeEntity[]{}).AsQueryable();
    foreach(var pair in array)
    {
      var temp=pair;
      query=query.Union(
        _db.SomeEntity.Where(s=>s.SomeProp>=temp.start && s.SomeProp<=temp.end));
    }
