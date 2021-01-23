    public virtual void Update<TEntity>(TEntity entity)
        where TEntity : class
    {
        context.Set<TEntity>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }
    
    public virtual void Save()
    {
        try
        {
            context.SaveChanges();
        }
        catch (DbEntityValidationException ex)
        {
            var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);
            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        }
    }
