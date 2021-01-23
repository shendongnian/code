        private static Exception SaveDataItemsToDatabase(List<IDataItem> dtos)
        {
            using (var db = new DbConnection())
            {
                try
                {                    
                    db.Data.BeginTransaction();
                    foreach (var dataType in dtos.GroupBy(x => x.GetType())) {
                        var type = dataType.Key;
                        var items = dataType.ToArray();
                        var insert = db.Data.GetType().GetMethod("BulkInsert").MakeGenericMethod(type);
                        // create array of Type[]
                        var casted = Array.CreateInstance(type, items.Length);
                        Array.Copy(items, casted, items.Length);
                        // invoke
                        insert.Invoke(db.Data, new object[] {casted});
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
