    public void UpdateClient(int clientId, bool hasPaid)
    {
        using (SqlConnection conn = new SqlConnection(this.myConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand("uspUpdatePaymentStatus", conn))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
                sqlCommand.Parameters.Add("@HasPaid", SqlDbType.Bit).Value = hasPaid;
                sqlCommand.Connection.Open();
                var rowsAffected = sqlCommand.ExecuteNonQuery();
            }
        }
    }
