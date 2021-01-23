      public ActionResult PayOutConfirmation()
      {
         var ticketPayOutModel = new TicketPayoutModel();
         ticketPayOutModel .Logo = "test";
         return View(ticketPayOutModel );
      }
