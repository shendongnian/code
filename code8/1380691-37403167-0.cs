    var roomCost = 100.0; // whatever the room cost based on the room type
    // You should probably use try parse
    var RoomType = string.IsNullOrEmpty(txtRoomType.Text) ? 1 : Convert.ToInt32(txtRoomType.Text.Trim());
    var NoOfRooms = string.IsNullOrEmpty(txtNoOfRooms.Text) ? 1 : Convert.ToInt32(txtNoOfRooms.Text.Trim());
    var NoOfNights = string.IsNullOrEmpty(txtNoOfNights.Text) ? 1 : Convert.ToInt32(txtNoOfNights.Text.Trim());
    var totalCostHotel = (roomCost * NoOfRooms) * NoOfNights;
    // you will need to change the connection string to what you need
    var connectionString = "server=localhost;database=testdb;Integrated Security=true;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	var queryString = new StringBuilder();
    	queryString.AppendLine("INSERT INTO [dbo].[HotelData]");
    	queryString.AppendLine("([RoomType],[NoOfRooms],[NoOfNights],[totalCostHotel])");
    	queryString.AppendLine("VALUES (@RoomType, @NoOfRooms, @NoOfNights, @totalCostHotel)");
    	try
    	{
    		SqlCommand command = new SqlCommand(queryString.ToString(), connection);
    		command.Connection.Open();
    		command.Parameters.AddWithValue("@RoomType", RoomType);
    		command.Parameters.AddWithValue("@NoOfRooms", NoOfRooms);
    		command.Parameters.AddWithValue("@NoOfNights", NoOfNights);
    		command.Parameters.AddWithValue("@totalCostHotel", totalCostHotel);
    		command.ExecuteNonQuery();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
