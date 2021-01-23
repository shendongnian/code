    public static bool Exists(string ID)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SimpleDB"].ToString();
        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(@"
                          IF EXISTS(SELECT 1 FROM Book Where Name = @ID)
                          SELECT 1 ELSE SELECT 0" , con))
        {
             con.Open();                                     
             cmd.Parameters.AddWithValue("@ID", ID);
             int result = Convert.ToInt32(cmd.ExecuteScalar()); 
             return (result == 1);
        }
    }
