    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Chip_Master chipMaster)
    {
        if (ModelState.IsValid)
        {
            chipMaster.Mask_Concat = Request.Form["selectedValues"];
            db.Chip_Master.Add(chipMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(chipMaster);
    }
