    [HttpPost]
    public ActionResult Book(BookingViewModel model)
    {
      var isGood = hotelService.DoesCurrentUserHasAccessToRoom(model.RoomId);
      if(isGood)
      {
         //Continue with Saving
         hotelService.BookRoom(model);
         return RedirectToAction("BookingCompleted");
      }
      return View("NotAuthorized");
    }
