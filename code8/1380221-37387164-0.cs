            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Console")] GameCreation game)
            {
                if (ModelState.IsValid)
                {
                    db.Games.Add(game);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(game);
            }
