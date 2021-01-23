    public ActionResult Tickets(string id)
    {           
        ViewData["id"] = id;
        TempData["id"] = id;
        return View("Ticket");
    }
