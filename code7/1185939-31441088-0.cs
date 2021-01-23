    var a = db.As.Find(id);
    var removals = a.Bs.ToList(); //or you could filter to only remove B objects matching a specific criteria, etc.
    foreach (var remove in removals)
    {
       a.Bs.Remove(remove);
    }
    db.SaveChanges();
