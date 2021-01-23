    public IQueryable<Device> GetAllDevices(params Expression<Func<Device, object>>[] includes)
    {
        IQueryable<Device> query = this.Repository.GetAll(includes);
        if (includes != null && includes.Length != 0)
        {
            query = query.Include(x => x.Capabilities);
        }
        return query;
    }
