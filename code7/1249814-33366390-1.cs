    public DataTable GetDataTableFromCacheOrDatabase()
    {
       DataTable dataTable = HttpContext.Current.Cache["UNIQUE SEARCH KEY"] as DataTable;
       if(dataTable == null)
       {
           dataTable = GetDataTableFromDatabase();
           HttpContext.Current.Cache["UNIQUE SEARCH KEY"] = dataTable;
       }
       return dataTable;
    }
