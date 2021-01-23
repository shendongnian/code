    public DataTable ExecuteStoredProcedure(string storedProcedure,
                                            List<StoredProcedureParameters> spParams = null)
    {
        //...
 
        if (spParams != null) // Check if the spParams is null
        {
            foreach(var param in spParams)
            {
                // Loop in here, if not null
            }
        }
        //...
    }
