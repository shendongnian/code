     public ActionResult CreateSupplier()
    {
        var suppliers = db.Suppliers;
        ViewBag.Suppliers = suppliers;
        return View();
    }
    [HttpPost]
    public ActionResult CreateSupplier(Supplier supplier)
    {
      try{
        if (ModelState.IsValid)
        {
            supplier.CreatedbyUserId = Convert.ToInt32(this.Session["_SessionUserId"]);
            supplier.UpdatedbyUserId = Convert.ToInt32(this.Session["_SessionupdatedUserId"]);
            supplier.CreatedDate = Convert.ToDateTime(this.Session["_SessionDate"]);
    Suppliers objSup = new Suppliers();
     objSup = db.Suppliers.Where(x=>x.CreatedbyUserId ==supplier.CreatedbyUserId).FirstOrDefault();
    if(objSup !=null){
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return Redirect("CreateSupplier");  
        }
    else{
     ModelState.AddModelError("","Suplier already exists.");
        }
        }
        }
    catch (Exception ex)
        {
           throw (ex);
        }
        else   
        {
            return View();
        }
    }
