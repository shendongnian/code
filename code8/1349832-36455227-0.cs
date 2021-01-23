       private static Exception SaveDataItemsToDatabase(List<IDataItem> dtos)
       {
            using (var db = new DbConnection())
            {
                try
                {
                    var dtosByType = dtos.GroupBy(x => x.GetType());
    
                    db.Data.BeginTransaction();
                    var method = db.Data.GetType().GetMethod("InsertBulk");
                    foreach (var dataType in dtosByType)
                    {
                        var genericMethod = method.MakeGenericMethod(dataType.Key);
                        genericMethod.Invoke(db.Data, new object[] { dataType.Value };                   
                    }
    
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
