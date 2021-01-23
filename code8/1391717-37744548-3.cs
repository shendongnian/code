    [EnableQuery(PageSize = 100)] // For server-driven paging -- recommended but not obligatory
    public IHttpActionResult GetTableResult()
    {
        return appDbCtx.Composite;
    }
