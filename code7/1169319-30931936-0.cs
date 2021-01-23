    string connectionString = "yourConnectionString";
    string query = "INSERT INTO dbo.YourTable (ID, IDnumber, NAME) " + 
                   "VALUES (@Id, @IDnumber, @Name) ";
    // create connection and command
    using(SqlConnection cn = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand(query, cn))
    {
        // define parameters and their values
        cmd.Parameters.Add("@ID", ID);
        cmd.Parameters.Add("@IDnumber", IDnumber);
        cmd.Parameters.Add("@Name", Name); 
        //open, insert and close
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
