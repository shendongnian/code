    List<Reserve> resList = db.ReserveSet.Where(x => x.User.Contains(lending.User) 
        && x.Medium.Id.Equals(lending.Copy.Medium.Id)).ToList();
    //für alle Elemente 
    foreach (Reserve r in resList)
    {
        Reserve res =  db.ReserveSet.Find(r.Id);
        res.Served = true;
        db.Entry(res).State = EntityState.Modified;
        db.SaveChanges();
    }
