    private DataTable GetData()
    {
        DataTable dt = new DataTable();
        SqlConnection sqlCon = new SqlConnection("...");
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.CommandText = "SELECT top 10 * from products.products";
        sqlCmd.Connection = sqlCon;
    
        sqlCon.Open();
        dt.Load(sqlCmd.ExecuteReader());
        sqlCon.Close();
        return dt;
    }
