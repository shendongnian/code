    if (ModelState.IsValid)
    {
        db.Products.Add(product);        
        db.Products.ApplicationUser = currentUser; //depending how you have your user defined       
        db.SaveChanges();
        return RedirectToAction("Index");
    }
