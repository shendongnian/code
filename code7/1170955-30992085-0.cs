    public ActionResult Index(int? page)
    {
        List<ProviderViewModel> viewModel = new List<ProviderViewModel>();
        List<Provider> businessModel = db.Providers
                                         .OrderBy(t => t.Name);
        
        int pageSize = 9;
        int pageNumber = (page > 0 ? page : 1);
        int totalCount = businessModel.Count();
        foreach (Provider provider in businessModel.Skip(pageSize * (pageNumber - 1))
                                                   .Take(pageSize))
        {
           viewModel.Add(new ProviderViewModel(provider));
        }
                              
        return View(new StaticPagedList(viewModel, pageNumber, pageSize, totalCount));
    }
