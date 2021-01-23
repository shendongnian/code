    [HttpGet]
    public ActionResult Edit(int dealerId = 0)
    {
        //get from database
        Models.Dealer dealer = new Models.Dealer();
        string error;
        if (dealer.GetDealer(dealerId, out error))
        {
            return View(dealer);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
