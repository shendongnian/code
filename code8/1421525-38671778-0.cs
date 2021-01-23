     [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditGoogles([Bind(Include = "ProductID,Name,Code,Quantity,etc)] SalesDetail salesdetail)
    {
        if (ModelState.IsValid)
        {
         var oldValue =  db.Entry(salesdetail).GetDatabaseValues();
         //here i want to get the Quantity from database 
            int QtyBefore = db.Set<SalesDetail>().FirstOrDefault(x => x.Quantity == yourquantityid)?.Quantity ;
         db.Entry(salesdetail).State = EntityState.Modified;
    salesdetail.Quantity = //do some operaion with QtyBefore Here and update
         await db.SaveChangesAsync();
         return Json(new { success = true });
        }
        return PartialView("_EditSales", salesdetail);
    }
