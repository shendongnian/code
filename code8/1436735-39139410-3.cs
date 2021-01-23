    OracleCommand cmd = new OracleCommand(connectionObject);
    cmd.CommandText = "Oracle_PkrName.Stored_Proc_Name";
    cmd.CommandType = CommandType.StoredProcedure;
    //Add parameters that are needed
    //Then add the output cursor:
    objCmd.Parameters.Add("YourCursorNameInProcedure", OracleType.Cursor).Direction 
        = ParameterDirection.Output;
    connection.Open();
    cmd.ExecuteNonQuery();
    OracleDataAdapter da = new OracleDataAdapter(objCmd);
    da.Fill(dataset);  
                     
