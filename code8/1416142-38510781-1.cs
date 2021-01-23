    public void SQLInfo(string column)
    {
        SqlConnection Connect = new SqlConnection(
            "Server=server;Database=db;User ID=user;Password=pass;");
        Connect.Open();        
        SqlCommand com = new SqlCommand(
            string.Format("select distinct [{0}] from [dbo].[ServerAttributes]",column));
        SqlDataReader reader = com.ExecuteReader();
    }
