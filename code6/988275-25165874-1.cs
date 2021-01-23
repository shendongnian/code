    using System.Reflection;
    public IQueryable<ResultDataType> MatchingRecordFor(object entity)
    {
        var records = _context.DataBaseRecords;
    
        var entityType = entity.GetType();
        var properties = entityType.GetProperties().Where(p => p.PropertyType.Namespace == "System");
        Func<KeyType, PropertyInfo, bool> keyMatchesProperty =
           (k, p) => p.Name == k.DataBaseRecordKeyName && p.GetValue(entity).ToString() == k.DataBaseRecordValue;
        var result =
            from r in records
            where r.DataBaseRecordKeys.Any(k => properties.All(pr => keyMatchesProperty(k, pr)))
            from p in r.DataBaseRecordProperties
            select new ResultDataType()
            {
                ResultDataTypeId = r.ResultDataTypeId,
                SubmitDate = r.SubmitDate,
                SubmitUserId = r.SubmitUserId,
                PropertyName = p.PropertyName
            });
        return result.AsQueryable();
    }
