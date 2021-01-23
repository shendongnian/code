    public ActionResult Index(int? page)
    {
        // Order the collection before skipping.
        var firmas = db.Firmas.OrderBy(x => x.Name); // Or some property.
        if (Request.HttpMethod != "GET")
        {
            page = 1;
        }
        int pageSize = 2;
        int pageNumber = (page ?? 1);
    
        return View(firmas.ToPagedList(pageSize, pageNumber));
    }
