    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ProjectID,ProjectTitle,SelectedStatus")] Project project, Status status)
            {
                if (ModelState.IsValid)
                {
                    db.Statuses.Add(status);
                    db.Projects.Add(project);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(project);
            }
