    SqlDatabase sqlServerDB = new SqlDatabase(SqlHelper.GetConnectionString());
    
    string query = @"  EXEC Some_Proc";
    
    DbCommand cmd = sqlServerDB.GetSqlStringCommand(query);
    cmd.CommandTimeout = 120;
    
    SqlParameter temp = new SqlParameter("@DataArray", timesheetList);
    temp.SqlDbType = SqlDbType.Structured;
    temp.TypeName = "dbo.My_Custom_Table_Type_Name";
    cmd.Parameters.Add(temp);
    result = Convert.ToInt64(sqlServerDB.ExecuteNonQuery(cmd));
