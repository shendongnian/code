    public ActionResult StatusView()
    {
        var statusList = new List<ViewModels.Status>();
    
        using (var status = new Models.StatusDbContext())
        {
            statusList = Status.STATUS_T.ToList().Select(p => new ViewModels.Status {
                Property1 = p.Property1,
                Property2 = p.Property2,
                ...
            }).ToList();
        }
        return View(statusList);
    }
