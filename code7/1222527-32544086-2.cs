      [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create([Bind(Include = "ID,Name,Type")] User user, FormCollection formData)
                {
                    
                    if (ModelState.IsValid)
                    {
                        var ss = formData["ShipFromCountries"].ToString();
     user.WeposInList = db.Wepons.Where(c => c.Wepon_Name == ss).ToList();
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
        
                    return View(user);
                }
