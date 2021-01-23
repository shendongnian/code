    public List<BatchDetail> ReadBatchDetails(int id)
    {
        using (var myEntities = new MyEntities())
        {
            return myEntities.BatchDetails
                .Include("RunDetails") // This is the problem
                .AsNoTracking().ToList();
        }
    }
