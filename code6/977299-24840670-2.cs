    public ActionResult Customers(string country)
    {
        var search = (country == null ? "" : country);
        NORTHWNDEntities db = new NORTHWNDEntities();
        var query = from c in db.Customers
                    where c.Country.Contains(search)
                    select c;
        var results = new List<Customers>();
        results.AddRange(query);
        return View("Customers", results);
    }
