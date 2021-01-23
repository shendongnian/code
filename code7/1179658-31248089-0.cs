    public void Edit()
    {
        var location = db.Locations.Single(p => p.LocationId == 1);
        location.Tags.Clear(); // added this line
        location.Tags = db.Tags.Where(p => p.TagId == 1).ToList();
        db.Entry(location).State = EntityState.Modified;
        db.SaveChanges(); // TagId 1 now correctly attached
    }
