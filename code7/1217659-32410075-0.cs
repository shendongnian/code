    public ActionResult Edit(Guid? id)
    {
      ....
      BookingViewModel bookingViewModel = new BookingViewModel()
      {
        ....
      }
      // Call the ConfigureCreateViewModel() method so that you SelectList's are populated 
      // as you have done in the Create() method (ConfigureViewModel might be a better name?)
      ConfigureCreateViewModel(bookingViewModel);
      return View(bookingViewModel); // adjust this
    }
