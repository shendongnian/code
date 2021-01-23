    public async Task<KeyValuePair<String, List<BE_Category>>> CategoryList(BE_Category obj)
    {
        try
        {
            using (var categoryContext = new ModelGeneration())
            {
                using (var dbContextTransaction = categoryContext
                          .Database
                          .BeginTransaction(System.Data.IsolationLevel.Snapshot))
                {
                    categoryContext.Configuration.ProxyCreationEnabled = false;
                    
                    //Code
    
                    dbContextTransaction.Commit();
    
                    return new KeyValuePair<String, List<BE_Category>>("", data);
                }
            }
        }
        catch (Exception ex)
        {
            return new KeyValuePair<String, List<BE_Category>>(ex.Message, null);
        }
    }
