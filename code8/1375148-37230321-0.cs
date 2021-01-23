    public DataSet GetDataSet(string connectionString)
    {
        //Create connection object
        SqlConnection sqlCon = new SqlConnection(connectionString);
        SqlDataAdapter daAddWO = new SqlDataAdapter();
        SqlCommand cmd = sqlCon.CreateCommand();
        cmd.CommandText = ("SELECT user_ID, user_name FROM table WHERE user_id=@userID");
        //Initialise the parameter
        cmd.Parameters.AddWithValue("@userID", userID);
        //Pass the SQL query to the da
        daAddWO.SelectCommand = cmd;
        //Create the dataset
        DataSet dsAddWO = new DataSet();
        
        //Open the connection and fill the dataset
        sqlCon.Open();
        daAddWO.Fill(dsAddWO);
        sqlCon.Close();
        maxRows = dsAddWO.Tables[0].Rows.Count;
        //Return the dataset
        return dsAddWO;
    }
