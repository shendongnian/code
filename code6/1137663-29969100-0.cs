        var param1Parameter = param1 != null ?
        new SqlParameter("param1", param1) :
        new SqlParameter("param1", typeof(string));
        var param2Parameter = param2 != null ?
        new SqlParameter("param2", param2) :
        new SqlParameter("param2", typeof(int));
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<sp_TestSproc_Result>("sp_TestSproc @param1, @param2", param1Parameter, param2Parameter); 
