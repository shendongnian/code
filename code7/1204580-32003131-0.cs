    public ActionResult Index()
    {
        IList<TicketListModel> TicketList = new List<TicketListModel>();
        var TicketListQuery = from t in db.Tickets
                               
                              select new TicketListModel
                              {
                                  Number = t.Number,
                                  RequestDate = t.RequestDate,
                                  Applicant = (from a in db.Employees where a.ID = t.ID select a.Name).FirstOrDefault(),
                                  ComName = ComLibs.Name,
                                  ProbType = t.ProbType,
                                  ProbDetail = t.ProbDetail,
                                  Status = t.Status
                              };
        TicketList = TicketListQuery.ToList();
        return View(TicketList);
    }
