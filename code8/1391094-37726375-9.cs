    private IEnumerable<TEntity> GetEntityData<TEntity>(int requestId, IEnumerable<TEntity> requestEntities, DateTime scanDateTime)
        where TEntity : BaseEntity
    {
        int SrNo = 0;
        foreach (var item in requestEntities)
        {
            item.DCDTime = DateTime.Now;
            item.LastModDTime = scanDateTime;
            item.ID = requestId;
            item.ScanDateTime = scanDateTime;
            item.SrNo = ++SrNo;
            yield return item;
        }
    }
