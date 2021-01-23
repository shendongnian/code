    [HttpPost]
    public ActionResult Create(Client client)
    {
        if (ModelState.IsValid)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return View("Success");
        }
        return View(); //Looks like you've missed this line because it shouldn't have compiled if result isn't returned in all code branches.
    }
