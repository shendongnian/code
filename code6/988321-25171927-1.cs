    public List<BatchDetail> ReadBatchDetailsWithoutRunDetails(int id)
    {
        using (var myEntities = new MyEntities())
        {
            return myEntities.BatchDetails.AsNoTracking().ToList();
        }
    }
