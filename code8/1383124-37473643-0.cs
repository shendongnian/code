    builder.EntityType<User>().Function("Dashboards").ReturnsCollectionFromEntitySet<Dashboard>("Dashboards");
    
    [HttpGet]
    [ODataRoute("Users({key})/Default.Dashboards()")]
    public IQueryable<Dashboard> Dashboards(int key)
    {
        // determine the user's rights
        return _db.Dashboard.Where ...
    }
