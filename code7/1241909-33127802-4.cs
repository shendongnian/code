        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(RecipeLineCustomBinder))] RecipeLine recipeLine)
        {
            if (ModelState.IsValid)
            {
                db.RecipeLines.Add(recipeLine);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = recipeLine.RecipeId });
            }
            return View(recipeLine);
        }
