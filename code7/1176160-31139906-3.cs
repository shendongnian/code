    // PUT api/fleet/5
    public void Put(Fleet fleet)
    {
        db.Entry(fleet).State = EntityState.Modified;
        foreach (var item in fleet.FleetAttributes)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        db.SaveChanges();
    }
