    // POST: VRs/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public IActionResult Edit(VRViewModel vRVM)
                {
                    if (ModelState.IsValid)
                    {
                        VR vR = new VR();
                        //Attach the instance so that we don't need to load it from the DB
                        _context.MyVR.Attach(vR);
                        
                        //Set the Id for your model.
                        vR.Id = vRVM.Id;
                        //Let's say you also want to update this field from the VM
                        vR.FullName = vRVM.FullName;
    
                        vR.ModifiedBy = User.Identity.Name;
                        vR.Modified = DateTime.Now;
        
                        //Specify the fields that should be updated.
                        _context.Entry(vR).Property(x => x.ModifiedBy).IsModified = true;
                        _context.Entry(vR).Property(x => x.Modified).IsModified = true;
                        _context.Entry(vR).Property(x => x.FullName).IsModified = true;
        
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    //create your new view model and return it. For demonstration purpose, I return the same view model, in your real code, you can adjust it.
                    return View(vRVM);
                }
