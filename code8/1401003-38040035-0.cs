    if (objProduct != null) 
    {
        _entities.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
        _entities.SaveChanges();
    }
