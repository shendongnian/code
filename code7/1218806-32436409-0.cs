    [HttpPost]
    public ActionResult Index(BookingModel bookingModel)
    {
      if (ModelState.IsValid)
      {
         TempData["BM"] = bookingModel;
         return RedirectToAction("Result");
      }
      return View(bookingModel);
    }
