    public ActionResult Index()
    {
        IList<TicketListModel> TicketList = new List<TicketListModel>();
        var TicketListQuery = from t in db.Tickets
    
                              select new TicketListModel
                              {
                                  Number = t.Number,
                                  RequestDate = t.RequestDate,
                                  Applicant = t.Applicant.Name,
                                  ComName = t.ComLib.Name,
                                  ProbType = t.ProbType,
                                  ProbDetail = t.ProbDetail,
                                  Status = t.Status
                              };
        TicketList = TicketListQuery.ToList();
        return View(TicketList);
    }
