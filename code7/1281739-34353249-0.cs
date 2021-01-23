        public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Thread thread = db.Threads.Find(id);
                string userId = User.Identity.GetUserId();
                if (thread == null || thread.ApplicationUserId != userId)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryId = new SelectList(db.Categorys, "Id", "Title", thread.CategoryId);
                return View(thread);
            }
            [HttpPost]
            [ValidateInput(false)]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,Title,Content,CategoryId")] Thread thread)
            {
                if (ModelState.IsValid)
                {
                    Thread t = db.Threads.Include(m => m.ApplicationUser).FirstOrDefault(m => m.Id == thread.Id);
                    t.Content = thread.Content;
                    t.Title = thread.Title;
                    db.Entry(t).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Post", "Threads", new { @id = thread.Id });
                }
                return View(thread);
            }
