    [HttpGet]
    public virtual TEntity GetById(int id)
    {
        try
        {
            var data = GetDataById(id);
            return data; 
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public virtual TEntity GetbyId(int id)
    {
        var data = _ctx.Set<TEntity>().Where(e => e.Id == id);
        var entity = data.FirstOrDefault();
        return entity;
    }
