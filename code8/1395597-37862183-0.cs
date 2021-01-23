    public override int SaveChanges()
    {
         Invites
            .Local
            .Where(r => r.HouseHold== null)
            .ToList()
            .ForEach(r => Invites.Remove(r));
     
        return base.SaveChanges();
    }
