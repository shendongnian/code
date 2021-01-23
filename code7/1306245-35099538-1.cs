    [WebMethod]
    public static bool DeleteCustomer(int customerId)
    {
        string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId"))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected > 0;
            }
        }
    }
