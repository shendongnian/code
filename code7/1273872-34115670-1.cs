    sqlConnection = new SqlConnection(conn);     
        System.Data.SqlClient.SqlDataAdapter SqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter("CDRCOLLECT", sqlConnection);
        SqlDataAdapter1.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
    //for add parameter
    //SqlDataAdapter1.SelectCommand.Parameters.Add("@param1", System.Data.SqlDbType.NVarChar);
    //SqlDataAdapter1.SelectCommand.Parameters["@param1"].Value = DropDownList1.SelectedValue;
        System.Data.DataSet DataSet1  = new System.Data.DataSet();
        SqlDataAdapter1.Fill(DataSet1 , "0");
        if (DataSet1.Tables["0"].Rows.Count > 0)
        {
        //you can use DataSet1.Tables["0"] for access your output data
        }
