    private IEnumerable<TEntity> GetEntityData<TEntity>(int requestId, IEnumerable<TEntity> requestEntities, DateTime scanDateTime)
        where TEntity : BaseEntity, new()
    {
        int SrNo = 0;
        foreach (var item in requestEntities)
        {
            TEntity d = new TEntity();
            d = item;
            d.DCDTime = DateTime.Now;
            d.LastModDTime = scanDateTime;
            d.ID = requestId;
            d.ScanDateTime = scanDateTime;
            d.SrNo = ++SrNo;
            yield return item;
        }
    }
