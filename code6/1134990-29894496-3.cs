    while (dr.Read())
    {
        newItem = new TicketBooking();
        newItem.Title = dr["Title"].ToString();
        newItem.DateReleased = Convert.ToDateTime(dr["DateReleased"]);
        newItem.TheaterName = dr["TheaterName"].ToString();
        ...
        ...
    }
