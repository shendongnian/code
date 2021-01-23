    public IViewComponentResult Invoke(string filter)
    {
        DateTime todaysDate = new DateTime();
        todaysDate = DateTime.Now;
    
        var fcbVmList = (from p in ctx.Booking
                   join i in ctx.Venue on p.VenueId equals i.VenueId
                   where p.DonorId.Equals(filter)
                   where p.BookingDate >= todaysDate
                   select new FCBViewModel { BookingDate = p.BookingDate,
                                             VenueName = i.VenueName })
                   .toList();
        return View(fcbVmList);
    }
