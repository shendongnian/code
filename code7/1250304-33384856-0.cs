    int Id=3;
    IList<Demo> obj = repository.Query<Demo>();
    if (Id != 0)
    {
        obj = obj.Where(p => p.id == Id);
    }
    else
    {
        obj = obj.Where(...your condition...);
    }
    var result = obj.ToList();
