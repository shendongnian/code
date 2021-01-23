    public IQueryable<TEntity> GetActive()
    {
      if (typeof(IActivable).IsAssignableFrom(typeof(TEntity)))
      {
  	    Expression<Func<TEntity, bool>> getActive = x => ((IActivable)x).Active;
   	    getActive = (Expression<Func<TEntity, bool>>)RemoveCastsVisitor.Visit(getActive);
        return this.repository.Get().Where(getActive);
      }
      else
      {
        return this.Get();
      }
    }
