    protected void Create<TEntity>(TEntity modelOf) where TEntity : class, new()
        {
          if (ModelState.IsValid)
          {
            db.Set<TEntity>().Add(modelOf);
            db.SaveChanges();
          }
        }
