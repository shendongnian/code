    sqlConnection = new SqlConnection(conn);     
    System.Data.SqlClient.SqlDataAdapter SqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter("CDRCOLLECT", sqlConnection);
    SqlDataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
    System.Data.DataSet DataSet  = new System.Data.DataSet();
    SqlDataAdapter.Fill(DataSet , "0");
    if (DataSet.Tables["0"].Rows.Count > 0)
    {
    //you can use DataSet.Tables["0"] for access your output data
    }
