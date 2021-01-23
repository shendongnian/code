    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,NameOnCard,CardNumber,ValidFrom,Expires,SecurityCode,Address,TownCity,Country,PostCode")] Payment payment)
    {
    	if (ModelState.IsValid)
    	{
    		db.Payments.Add(payment);
    		db.SaveChanges();
    		
    		return RedirectToAction("Details", new { id = payment.ID);
    
    	}
    	return View(payment);
    
    }
    
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Payments payment = db.Payments.Find(id);
      if (payment == null)
      {
          return HttpNotFound();
      }
      return View(payment);
    }
