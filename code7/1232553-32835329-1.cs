    public void DoUpdate<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) => validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) => current + (Environment.NewLine + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));
            var fail = new Exception(msg, dbEx);
            throw fail;
        }
    }
