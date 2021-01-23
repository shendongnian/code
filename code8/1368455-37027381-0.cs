    public ActionResult brand(int brand_Id = 0)
    {
       var model = db.MVCs.Where(i => i.brand_Id == brand_Id).ToList();
       if (model == null)
       {
           return HttpNotFound();
       }
       return View(model);
    }
