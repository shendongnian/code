    var entity = Mapper.Map<Entity>(entityModel);  //parent properties
    foreach (var id in  AttachementsIds)
    {
        entity.Attachements.Add(new Attachement { Id = id });
    }
    dbContext.Entities.Add(entity);
    dbContext.SaveChanges();
