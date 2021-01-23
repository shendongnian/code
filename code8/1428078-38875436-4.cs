    public T GetById<T>(Guid id) where T : new()
    {
        T entityBo = new T();
        // this should not be needed, you do not use the results anywhere unless your EF type provides for some defaults at the BLL layer but it would be better to include those defaults in the BLL types constructor instead
        // var entity = new EntityFactory().CreateEntity<T>(); // That's the problem line: T is UsersBo, but I need a new Users (EF entity) in order to do the mapping later
        // this is the line where you need to implement the translation to get the correct repository type
        var repository = new EntityFactory().CreateRepository<T>();
        try
        {
            // get your object from your repository or if it returns nothing then create a default instance
            var entity = repository.GetById(id);
            if (entity != null)
            {
                // map what was returned
                Mapper.Map(entity, entityBo);
            }
        }
        catch (Exception ex)
        {
            // no need for this, it adds nothing
            // entityBo = default(T);
            // do not do this
            // throw ex.GetBaseException();
            // this is better, it preserves the stack trace and all exception details
            throw;
        }
        return entityBo;
    }
