    [HttpPost]
    public ActionResult Create(Client client)
    {
        if (ModelState.IsValid)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Success");
        }
        return View(); //Looks like you've missed this line because it shouldn't have compiled if result isn't returned in all code branches.
    }
    public ActionResult Success(Client client)
    {
        //...
        return View();//By default it will use name of the Action ("Success") as view name. You can specify different View if you need though.
    }
