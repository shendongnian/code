    public ActionResult Create([Bind(Include = "StockId,Name,Ticker")] Stock stock)
    {
        if (ModelState.IsValid)
        {
            stock.UserID = User.Identity.GetUserId();
            db.Stocks.Add(stock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(stock);
    }
      
