    var aExists = _db.Model.Find(newOrOldOne.id);
    if(aExists==null)
    {
        _db.Model.Add(newOrOldOne);
    }
    else
    {
        _db.Entry(aExists).State = EntityState.Detached;
        _db.Entry(newOrOldOne).State = EntityState.Modified;
    }
