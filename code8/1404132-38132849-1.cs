    System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
    string database = builder.InitialCatalog;
    using(SqlConnection con = new SqlConnection(Connectionstring)) 
    {
        con.Open();
        String sqlCommandText = @"
            ALTER DATABASE " + database + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE [" + database  + "]";
        SqlCommand sqlCommand = new SqlCommand(sqlCommandText, con);
        sqlCommand.ExecuteNonQuery(); 
    }
