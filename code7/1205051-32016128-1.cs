    private DataTable GetData(string searchTerm)
    {
        DataTable dt = null;
        // Check to see if search term is null or empty
        if(!string.IsNullOrEmpty(searchTerm)
        {
            // Build SQL statement with WHERE clause
            using (SqlConnection sqlCon = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Inventory] 
                                       WHERE [Type] = @searchTermParameter";
                    cmd.Parameters.Add(new SqlParameter("@searchTermParameter", searchTerm));
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                }//end using
            }//end using
        }
        else
        {
            // Build SQL statement without WHERE clause,
            // because we are not searching for anything
            using (SqlConnection sqlCon = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Inventory]";
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                }//end using
            }//end using
        }
        return dt;
    }
