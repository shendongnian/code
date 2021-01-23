            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(benedet benedet)
            {
                
                if (ModelState.IsValid)
                {
                   for(int i=0;i<benedet.damagedets.Count;i++)
                    {
                        db.Entry(benedet.damagedets[i]).State = EntityState.Modified;
                    }
                    for (int i = 0; i < benedet.bankdets.Count; i++)
                    {
                        db.Entry(benedet.bankdets[i]).State = EntityState.Modified;
                    }
                    for (int i = 0; i < benedet.imagedets.Count; i++)
                    {
                        db.Entry(benedet.imagedets[i]).State = EntityState.Modified;
                    }
                    db.Entry(benedet).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(benedet);
            }
