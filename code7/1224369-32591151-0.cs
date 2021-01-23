    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ServiceNeeded")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                db.People.Add(person);
     
                foreach (var service in person.ServicesNeeded)
                     db.ServicesNeeded.Add(service);
    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(person);
        }
