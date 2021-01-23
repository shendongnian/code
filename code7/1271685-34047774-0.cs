    // POST: Admin/Products/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,ProductID,Name,CategoryID,Price,Promotion,Image1,Image2,Image3,Image4,Description,ClientID")] Product product, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
    {
        if (ModelState.IsValid)
        {
            if (file1 != null)
            {
                var fileName1 = Path.GetFileName(file1.FileName);
                var path1 = Path.Combine(Server.MapPath("~/Images/Products/"), fileName1);
                file1.SaveAs(path1);
    
                @product.Image1 = Url.Content("~/Images/Products/" + fileName1);
            }
    
            if (file2 != null)
            {
                var fileName2 = Path.GetFileName(file2.FileName);
                var path2 = Path.Combine(Server.MapPath("~/Images/Products/"), fileName2);
                file2.SaveAs(path2);
    
                @product.Image2 = Url.Content("~/Images/Products/" + fileName2);
            }
    
            if (file3 != null)
            {
                var fileName3 = Path.GetFileName(file3.FileName);
                var path3 = Path.Combine(Server.MapPath("~/Images/Products/"), fileName3);
                file3.SaveAs(path3);
    
                @product.Image3 = Url.Content("~/Images/Products/" + fileName3);
            }
    
            if (file4 != null)
            {
                var fileName4 = Path.GetFileName(file4.FileName);
                var path4 = Path.Combine(Server.MapPath("~/Images/Products/"), fileName4);
                file4.SaveAs(path4);
    
                @product.Image4 = Url.Content("~/Images/Products/" + fileName4);
            }
    
            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        string domain = Request.Url.Host;
        int clientid = (from a in db.Client where a.Domain == domain select a.ID).First();
    
        List<SelectListItem> categories = new List<SelectListItem>();
        foreach (var cat in db.Category.Where(c => c.ClientID == clientid))
        {
            categories.Add(new SelectListItem() { Text = cat.Name, Value = cat.CategoryID.ToString() });
            } 
        ViewBag.Categories = categories;
        return View(product);
    }
