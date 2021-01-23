    public virtual async Task<bool> InsertOrUpdate(TE entity)
    {
        if (entity.Id == 0 || entity.Id == ModelState.New)
        {
            // insert new item
            _context.Entry<TE>(entity).State = EntityState.Added;
        }
        else
        {           
            var attachedEntity = _context.ChangeTracker.Entries<TE>().FirstOrDefault(e => e.Entity.Id == entity.Id);
            if (attachedEntity != null)
            {
                // the entity you want to update is already attached, we need to detach it and attach the updated entity instead
                _context.Entry<TE>(attachedEntity.Entity).State = EntityState.Detached;
            }
            _context.Entry<TE>(entity).State = EntityState.Modified; // Attach entity, and set State to Modified.
            _context.Entry<TE>(entity).Property(o => o.CreatedUserId).IsModified = false;
            _context.Entry<TE>(entity).Property(o => o.CreatedDate).IsModified = false;
        }
        return await _context.SaveChangesAsync() > 0;
    }
