    string s = "12/25/2015 2:00:00 PM";
    DateTime checkIn = DateTime.Parse(s, CultureInfo.GetCultureInfo("en-US")).Date.AddHours(14);
    // ....
    string strInsert = "INSERT INTO Reservation (checkInDate, checkOutDate) VALUES (@checkInDate, @checkOutDate)";
    
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using (SqlCommand cmdInsert = new SqlCommand(strInsert, conn))
    	{
    		cmdInsert.Parameters.Add(new SqlParameter("@checkInDate", System.Data.SqlDbType.DateTime2).Value = checkIn);
    		// ....
    	}
    }
