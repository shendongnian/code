    public static void InsertUpdateDataTable(string strTableName, System.Data.DataTable dt)
    {
    	string strSQL = string.Format("SELECT * FROM [{0}] WHERE 1 = 2 ", strTableName.Replace("]", "]]"));
    
    	using (System.Data.SqlClient.SqlDataAdapter daInsertUpdate = new System.Data.SqlClient.SqlDataAdapter(strSQL, getConnectionString())) {
    		SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(daInsertUpdate);
    		daInsertUpdate.InsertCommand = cmdBuilder.GetInsertCommand();
    		daInsertUpdate.UpdateCommand = cmdBuilder.GetUpdateCommand();
    
    		daInsertUpdate.Update(dt);
    	}
    
    }
