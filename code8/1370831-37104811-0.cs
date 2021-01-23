    public List<Entity> GetEntities()
    {
        SdmDBContext entityDbContext = new SdmDBContext();
        return entityDbContext.Entities.Include("Names").ToList();
    }
