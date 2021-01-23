    List<Reserve> resList = db.ReserveSet.Where(x => x.User.Contains(lending.User)
         && x.Medium.Id.Equals(lending.Copy.Medium.Id)).ToList();
    foreach(var res in resList)
    {
       res.Served = true;
    }    
    db.SaveChanges();
