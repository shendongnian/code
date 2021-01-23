    // GET: /Create
    public ActionResult Create()
        {
            EventBookingViewModel eventBookingViewModel = new EventBookingViewModel
            {
                EventTypes = new SelectList(methodToReturnAListToHere(), "ValueColumn", "DisplayColumn")
            };
		    return View(eventBookingViewModel);
        }
