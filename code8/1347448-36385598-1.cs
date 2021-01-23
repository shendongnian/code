    public ActionResult Index(BookingsListView view)
        {
            if (view.StartDate == null)
                view.StartDate = DateTime.Now.Date;
            if (view.EndDate == null)
                view.EndDate = DateTime.Now.Date;
            var endDateLimit = view.EndDate.Value.AddDays(1);
            // Use view.Selected to find the current selected resturant
            view.Bookings = from b in db.Bookings.Include("Restaurant")
                where b.StartTime >= view.StartDate && b.StartTime < endDateLimit
                select b;
            view.Restaurants = dbRestaurant.Restaurants.OrderBy(r => r.Id).ToList();
            return View(view);
        }
