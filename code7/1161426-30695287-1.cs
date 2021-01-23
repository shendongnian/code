    public override void Add(Booking booking)
            {
                // Don't allow a new booking if the room is already out.
        
                var currentBooking = _ctx.Bookings
                    .Where(b => b.RoomId == booking.RoomId && 
            (booking.CheckIn <= b.CheckOut && booking.CheckIn >= b.CheckIn ||
             b.CheckIn <= booking.CheckOut && b.CheckIn >= booking.CheckIn))               
                    .FirstOrDefault();
        
                if (currentBooking != null)
                {
                      throw new BookingException("The Room is already out on that date.");
                }
        
                _ctx.Set<Booking>().Add(booking);
                _ctx.SaveChanges();
            }
