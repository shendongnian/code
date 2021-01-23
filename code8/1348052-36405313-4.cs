    [HttpPost]
    public ActionResult Create(MyCreateVM viewModel)
    {
      if(ModelState.IsValid)
      {
        db.DailySummaries.Add(viewModel)
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        ModelState.AddModelError("", "There was a problem");
    
        //...some code here to repopulate drop downs
    
        return View(viewModel);
      }
    }
