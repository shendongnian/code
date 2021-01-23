    public void SQLInfo(string column)
    {
        SqlConnection Connect = new SqlConnection(
            "Server=server;Database=db;User ID=user;Password=pass;");
        Connect.Open();        
        SqlCommand com = new SqlCommand(
            $"select distinct [{column}] from [dbo].[ServerAttributes]");
        SqlDataReader reader = com.ExecuteReader();
    }
