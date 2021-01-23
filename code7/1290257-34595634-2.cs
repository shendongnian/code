    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "CustomerId,FirstName)] 
                                                                              Customers model)
    {
    
        if (ModelState.IsValid)
        {
          var c = db.Customers.FirstOrDefault(s=>s.CustomerId==model.CustomerId);
          if(c!=null)
          {
             c.FirstName = model.FirstName; //update the property value
          
             db.Entry(c).State = EntityState.Modified;
             await db.SaveChangesAsync();
             return RedirectToAction("Index");
          }
        }
   
     }
