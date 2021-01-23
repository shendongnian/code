    // PUT api/fleet/5
    public void Put(Fleet fleet)
    {
        db.Entry(fleet).State = EntityState.Modified;
        db.SaveChanges();
    }
