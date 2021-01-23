    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddDetails(OrdersDetail orderDetails)
    {
       if (ModelState.IsValid)
       {
          db.OrdersDetail.Add(orderDetails);
          db.SaveChanges();
          
          return RedirectToAction("DetailsGridPartial", new { OrderId =  orderDetails.folio });
       }
       return View(order);
    }
    
    public ActionResult DetailsGridPartial(int OrderId)
    {
          var orderDetails = db.OrdersDetail.Where(w => w.folio == OrderId);
          return PartialView(orderDetails);
    }
