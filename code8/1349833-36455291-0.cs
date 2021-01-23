    private static Exception SaveDataItemsToDatabase(List<IDataItem> dtos)
    {
        using (var db = new DbConnection())
        {
            try
            {
    
                db.Data.BeginTransaction();
    
                dtos
                    .GroupBy(dto => dto.GetType())
                    .ForEach(grp => {
                        db.Data.BulkInsert(dtos.Where(n => n.GetType().Equals(grp.Key).ToList());
                    });
    
                db.Data.CommitTransaction();
    
                return null;
            }
            catch (Exception ex)
            {
                db.Data.RollbackTransaction();
    
                return ex;
            }
        }
    }
