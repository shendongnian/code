    decimal sum = 0;
    var booking = db.Bookings
            .Where(p => p.Id == id && 
                        p.StartDate.Year == DateTime.Now.Year);
    if(bookings.Any())
    {
        sum = booking.Sum(t => t.Price);
    }
