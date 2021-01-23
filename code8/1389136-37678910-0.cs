    public async Task UpdateAsync(List<TEntity> entities)
    {
      foreach (TEntity entity in entities)
      {
        BeforeUpdate(entity);
        Context.Entry(entity).State = EntityState.Modified;
      }
      await SaveChangesAsync();
    }
