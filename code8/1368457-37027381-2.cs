    public ActionResult brand(int brand_Id = 0)
    {
       var model = db.MVCs.Where(i => i.brand_Id == brand_Id).OrderBy(b => b.Brand.Brand_name).ToList();       
       if (model == null)
       {
           return HttpNotFound();
       }
       return View(model);
    }
