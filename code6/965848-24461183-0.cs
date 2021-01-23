    private DataTable GetData()
    {
    DataTable dt;
            string connectionString = ConfigurationManager.ConnectionStrings["yourConnection"].ConnectionString;
	        //
	        // In a using statement, acquire the SqlConnection as a resource.
	        //
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //
                // Open the SqlConnection.
                //
                con.Open();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT top 10 * from products.products", con))
                {
                    //use SqlDataAdapter to fill the dataTable
                    using (SqlDataAdapter a = new SqlDataAdapter(command))
                    {
                        dt = new DataTable();
                        a.Fill(dt);
                    }
                   
                }
            } 
            return dt;
        }
