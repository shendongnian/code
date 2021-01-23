    public void InsertCustomer(Integer customerID, DateTime activityDate) {
        String sql = "INSERT INTO Customers (customerID, ActivityDate) VALUES (@customerID, @activityDate);";
        Data.SqlClient.SqlCommand cmd = new Data.SqlClient.SqlCommand(sql);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@customerID ", Data.SqlDbType.Int).Value = customerID;
        cmd.Parameters.Add("@activityDate ", Data.SqlDbType.DateTime).Value = activityDate;
        try {
            using (SqlConnection connection = new Data.SqlClient.SqlConnection(YourConnectionString)) {
                connection.Open();
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            throw ex;
        }
    }
