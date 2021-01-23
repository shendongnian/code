    private void InsertMyData(string UserId, DateTime DayMonthYear, double Price, string Address)
    { 
    	using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    		SqlCommand cmd = new SqlCommand("INSERT INTO [Order] ([UserID],[DayMonthYear],[PriceToPay],[StatusID],[AdressToSend]) 
    										 VALUES (@UserId, @DayMonthYear, @Price, 1, @Address)";
    		cmd.CommandType = CommandType.Text;
    		cmd.Connection = connection;
    		cmd.Parameters.AddWithValue("@UserId", UserId);
    		cmd.Parameters.AddWithValue("@DayMonthYear", DayMonthYear);
    		cmd.Parameters.AddWithValue("@PriceToPay", Price);
    		cmd.Parameters.AddWithValue("@StatusID", 1);
    		cmd.Parameters.AddWithValue("@AdressToSend", Adress);
    		connection.Open();
    		cmd.ExecuteNonQuery();
    	}
    }
