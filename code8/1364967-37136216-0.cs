    if (entity.IsValidForAddOrUpdate())
    {
        db.Set<Entity>().Add(entity);
        db.SaveChanges()
    }
    else throw new DbValidationException("Entity failed validation due to rule xyz.");
