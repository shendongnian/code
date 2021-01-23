    public static DataTable GetUnloadingPointList(string whereClause, string connectionString)
                {
                    string strSql = @"SELECT * FROM view_ODW_SI_UnloadingPoints where 1=1 ";
    
                    if (!string.IsNullOrEmpty(whereClause))
                    {
                        strSql += " and  " + whereClause;
                    }
                     strSql += " order by id  " ;
