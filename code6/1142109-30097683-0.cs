    private DataTable GetData(SqlCommand cmd)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection myConnection = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(cmd, myConnection))
            {
                DataTable dtResult = new DataTable();
                myDataAdapter.Fill(dtResult);
                return dtResult;
            }
        }
    }
