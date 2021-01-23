    public ActionResult Index(string status)
    {
        IQueryable<Client> query = _context.Clients;
        if (status != "all")
        {
            query = query.Where(c => c.Cases.Any(cs => cs.Status == status));
        }
        var clients = query.ToList();
        // or query.Select(c => new { c.Id, c.Name }) ?
        return View(clients);
    }
