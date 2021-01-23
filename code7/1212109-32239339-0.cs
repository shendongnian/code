    public ActionResult PageList()
    {
        var keys = db.Keys.ToList();
        var prefix = "pagetitle_dynamic_";
        var display = keys.Where(x => x.Name.StartsWith(prefix));
    	var viewModelList = new List<PageListViewModel>();
    
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
