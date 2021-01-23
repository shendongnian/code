    [HttpPost]
    public ActionResult MakePayment(Downloads CCM)
    {
         if (everything is good)
         {
              return PartialView("Success");
         }
         else
         {
              return PartialView("Failure");
         }
    }
