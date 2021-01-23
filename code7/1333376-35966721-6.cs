    // POST: VRs/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(VR vR)
            {
                if (ModelState.IsValid)
                {
                    //Attach the instance so that we don't need to load it from the DB
                    _context.Entry(vR).State = EntityState.Modified; 
    
                    vR.ModifiedBy = User.Identity.Name;
                    vR.Modified = DateTime.Now;
    
                    //Specify the fields that should not be updated.
                    _context.Entry(vR).Property(x => x.Created).IsModified = false;
                    _context.Entry(vR).Property(x => x.CreatedBy).IsModified = false;
    
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(vR);
            }
