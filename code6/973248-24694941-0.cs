    [HttpPost]
    public ActionResult Create(Ienumerable<Client> clients)
    {
        if (ModelState.IsValid)
        {
            foreach(var client in clients)
            {  
               db.Clients.Add(client);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(client);
    } 
