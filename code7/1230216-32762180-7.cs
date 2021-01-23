    public virtual TEntity Remove(TEntity entity)
    {
      Check.NotNull<TEntity>(entity, "entity");
      this.GetInternalSetWithCheck("Remove").Remove((object) entity);
      return entity;
    }
