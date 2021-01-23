    [EnableQuery]
    public IHttpActionResult Get(int id)
    {
        var sets = dbContext.GetEmployeeById(id);
        if (!sets.Any())
            return NotFound();
        return this.CreateOKHttpActionResult(sets);
    }
