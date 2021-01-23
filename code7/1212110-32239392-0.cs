    public ActionResult PageList()
    {
        var keys = db.Keys.ToList();
        var prefix = "pagetitle_dynamic_";
        var display = keys.Where(x => x.Name.StartsWith(prefix));
        var viewModelList = new List<PageListViewModel>();
    
        return View(display.Select(item => new PageListViewModel
            {
                PageTitle = item.Name
            }
        ).ToList());
    }
