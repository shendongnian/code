    public ActionResult PageList()
    {
        List<PageListViewModel> viewModelList = new List<PageListViewModel>();
        var keys = db.Keys.ToList();
        var prefix = "pagetitle_dynamic_";
        var display = keys.Where(x => x.Name.StartsWith(prefix));
    
        foreach (var item in display)
        {
            var viewModel = new PageListViewModel
            {
                PageTitle = item.Name
            };
    
            viewModelList.Add(viewModel);
        }
        return View(viewModelList);
    }
