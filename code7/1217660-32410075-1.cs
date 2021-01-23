    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(BookingViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureCreateViewModel(model)
        return View(model);
      }
      // Get your data model and update its properties based on the view model
      Booking booking = db.Bookings.Find(id);
      booking.PracticeId = bookingViewModel.PracticeId;
      booking.OpticianId = bookingViewModel.OpticianId;
      .... // etc
      db.Entry(booking).State = EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("Index");
    }
