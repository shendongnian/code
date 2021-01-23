    public ObjectResult<int> GetAllStopsBetweenStations(int StopA_id, int StopB_id)
    {
        var A = new SqlParameter("StopA_id", System.Data.SqlDbType.Int);
        var B = new SqlParameter("StopB_id", System.Data.SqlDbType.Int);
    
        A.Value = StopA_id;
        B.Value = StopB_id;
    
        return ((IObjectContextAdapter)this).ObjectContext.
                ExecuteStoreQuery<int>("GetAllStopsInBetweenTest @StopA_id, @StopB_id ", A,B);
    }
