    public ActionResult AllCustomer()
    {
      return Json(db.Customers.ToList(), JsonRequestBehavior.AllowGet);
    }
    
     
