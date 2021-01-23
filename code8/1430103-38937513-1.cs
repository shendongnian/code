    public ActionResult GetPrice(int id)
    {
      // based on this id, Get the corresponding price
      decimal price = 100.0M; //replace with your value from db
      return Json(price,JsonRequestBehavior.AllowGet);
    }
