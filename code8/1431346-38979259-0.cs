    public ActionResult Create()
    {
        var departures = db.Flights.OrderBy(m => m.Departure)
                                                         .Select(i => i.Departure).Distinct();
        ViewBag.Departure = new SelectList(departures);
        ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
        ViewBag.TransportId = new SelectList(db.Transport, "TransportId", "Name");
        return View();
    }
