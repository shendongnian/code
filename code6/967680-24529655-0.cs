     [HttpPost]
    public ActionResult Create(int haveId1, int haveId2, int haveId2)
    {
        if (ModelState.IsValid)
        {
            Inventory inventory = new Inventory()
            {
                Have1 = haveId1,
                Have2 = haveId2,
                Have3 = haveId3
            };
            db.Pokemon.Add(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
