    public string GetEntityByName<TEntity>(int id)
    {
        using (var context = new MyContext())
        {
            dynamic entity = context.Set<TEntity>.Find(id);
            try
            {
                return entity.Name;
            }
            catch(Exception e)
            {
                // Handle the situation when requested entity does not have Name property
            }
        }
    }
