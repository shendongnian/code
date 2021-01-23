    [Queryable]
    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
    public virtual async Task<IHttpActionResult> Get(ODataQueryOptions<TEntity> options)
    {
        var source = db.Set<TEntity>().Where(e => !e.IsDeleted);
        var queryable = options.ApplyTo(source);
    
        var entities = await queryable.ToListAsync();
        return Ok(entities);
    }
