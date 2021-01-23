    public ActionResult Index()    
    {    
        CalendarViewModel model = new CalendarViewModel
            {
                NumberOfDays = 7,
                StartDate = DateTime.Now
            };
            return View(model);
    
    }
