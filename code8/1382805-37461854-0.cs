    if (ModelState.IsValid)
    {
        var entity = context.Entities.First(e => e.Id == viewmodel.Id); // fetch the entity
        Mapper.Map(viewmodel, entity); // Use automapper to replace changed data
        context.SaveChanges();
    }
