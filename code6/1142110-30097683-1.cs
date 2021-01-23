    private DataTable GetData(SqlCommand cmd)
    {
        string myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection myConn = new SqlConnection(myConnectionString))
        {
            cmd.Connection = myConn;
            using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(cmd))
            {
                DataTable dtResult = new DataTable();
                myDataAdapter.Fill(dtResult);
                return dtResult;
            }
        }
    }
