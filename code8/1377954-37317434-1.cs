    public static DataTable GetUnloadingPointList(string whereClause, 
                                                  string connectionString) {
      String strSql = String.Format(
        @"  SELECT * 
              FROM view_ODW_SI_UnloadingPoints 
               {0} 
          ORDER BY id",
        string.IsNullOrEmpty(whereClause) ? "" : "WHERE " + whereClause);
    
      ...
    
    }
