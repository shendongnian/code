    public ActionResult Index()
    {
        IList<CurrentViewModel> CaseList = new List<CurrentViewModel>();
        var query = .... // your existing query as in the question
        CaseList = query.ToList();
        foreach (var cvm in CaseList)
        {
            cvm.ViewingViewModels = .... // do the query to get the ViewingViewModels here
        }
        return View(CaseList);        
    }
