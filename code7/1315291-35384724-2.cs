     public ActionResult Create(Payments model)
     {
        ViewBag.Clients = new SelectList(db.ClientsList, "ClientsId", "ClientsName", model.clientID)
        return View();
    }
