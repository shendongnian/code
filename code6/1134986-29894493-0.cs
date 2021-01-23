    while (dr.Read())
    {
         newItem = new TicketBooking();
         newItem.Title = dr["Title"].ToString();
         newItem.DateReleased = Convert.ToDateTime(dr["DateReleased"]);
         newItem.TheaterName = dr["TheaterName"].ToString();
         newItem.Name = dr["Name"].ToString();
         newItem.PhoneNo = dr["PhoneNo"].ToString();
         newItem.Price = Convert.ToInt32(dr["Price"]);
         newItem.userName = dr["userName"].ToString();
         results.Add(newItem);
    }
    return View(results);  
