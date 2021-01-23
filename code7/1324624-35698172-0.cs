    using (SqlConnection sqlConnection = new SqlConnection())
    {
    	sqlConnection.ConnectionString = yourConnectionStringHere;
    	sqlConnection.Open();
    	SqlCommand sqlCommand = new SqlCommand("sys.sp_helptext", sqlConnection);
    	sqlCommand.CommandType = CommandType.StoredProcedure;
    	sqlCommand.Parameters.AddWithValue("@objname", "stored_proc_name_here");
    	DataSet ds = new DataSet();
    	SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    	sqlDataAdapter.SelectCommand = sqlCommand;
    	sqlDataAdapter.Fill(ds);
    	return DataTableToString(ds.Tables[0]);;
    }
