    [System.Web.Services.WebMethod]
    public static string DeleteData(string ID)
    {
            string connectionString = ConfigurationManager.ConnectionStrings["SimpleDB"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"Delete from Book 
                                                         Where Name = @ID" , con))
                {
                    con.Open();                                     
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();                   
                    con.Close();
                    return "True";
                }
            }
      }
