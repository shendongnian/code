    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        String sql = "UPDATE CounselorDB "+
                     "SET BookingID = @BookingID "+
                     "WHERE CounselorID = @CounselorID";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;
        cmd.Parameters.AddWithValue("@BookingID", getBookingID());
        cmd.Parameters.AddWithValue("@CounselorID", cID);
        connection.Open();
        cmd.ExecuteNonQuery();
    }
