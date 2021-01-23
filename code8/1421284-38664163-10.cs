    public ActionResult Index()
    {
        IList<CurrentViewModel> CaseList = new List<CurrentViewModel>();
        var query = .... // your existing query as in the question
        CaseList = query.ToList();
        foreach (var cvm in CaseList)
        {
            cvm.ViewingViewModels = (from sv in context.SaleViewings 
                                    where sv.CaseID == cvm.CaseID 
                                    select new ViewingViewModel
                                    {
                                        ID = sv.ID,
                                        CaseID = sv.CaseID,
                                        Date = sv.Date,
                                        Applicant = sv.Applicant,
                                        AgentID = sv.AgentID
                                    }).ToList();
        }
        return View(CaseList);        
    }
