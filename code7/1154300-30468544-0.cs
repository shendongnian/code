    using (SqlConnection conn = new SqlConnection(connString))
    {
          SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY FROM TABLE", conn);
            try
            {
                conn.Open();
                newID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
     }
