    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Diary diary)
    {
       if (!cd.Customers.Any(c => c.Id == diary.CustomerId)
       {
    	ModelState.AddModelError("CustomerId", "Customer not found");
        }
        if (ModelState.IsValid)
        {
            cd.Diaries.Add(diary);
            cd.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        return PartialView("_CreateDiary");
    }
