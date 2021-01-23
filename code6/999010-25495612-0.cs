    using (SqlConnection SqlConn = new SqlConnection(ConnString))
        {
             try
             {
                 SqlConn.Open();
             }
             catch (Exception ex)
             {
                 Debug.WriteLine(ex.ToString());
                 return null;
             }
    }
