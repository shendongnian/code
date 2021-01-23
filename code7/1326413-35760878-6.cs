    private void Populate_DataGrin(int intMonth, string strLocation)
    {
    	dtSomeDataTable = OracleDBHelper.ExecuteDataSet2(UserConnName, CommandType.StoredProcedure
    			   , new OracleParameter("var_IntMonth", intMonth)
    			   , new OracleParameter("var_StrLocation", strLocation)
    			   , new OracleParameter
    			   {
    				   ParameterName = "p_cursor"
    				 ,
    				   OracleDbType = OracleDbType.RefCursor
    				 ,
    				   Direction = ParameterDirection.Output
    			   }
    			 ).Tables[0];
    
    	YourDataGrid.DataSource = null;
    	YourDataGrid.DataSource = dtSomeDataTable;
    	YourDataGrid.DataBind();
    }
