    public IEnumerable<DomainModelResult> GetData()
    {
        var lst = this.EntityFrameworkDB.GetDataSproc().ToList();
        return lst
               .Select(sprocResults=>sprocResults.ToDomainModelResult())
               .AsEnumerable();
    }
