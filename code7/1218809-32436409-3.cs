    public ActionResult Result()
    {
       if (TempData["BM"] != null)
       {
         BookingModel bookingModel = (BookingModel) TempData["BM"];
         return View(bookingModel);
       }
       
    }
