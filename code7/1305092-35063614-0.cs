    Entity oldUnchanged;
    using (var ctx = new YourDbContext()) 
    {
        oldUnchanged = ctx.Set<Entity>().Single(x => x.Id == id);
    }
