    public ActionResult Index()
    {
        IList<TicketListModel> TicketList = new List<TicketListModel>();
        var TicketListQuery = from t in db.Tickets
                              from a in db.Employees
                              where t.ID == a.ID
                              select new TicketListModel
                              {
                                  t.Number,
                                  t.RequestDate,
                                  Applicant = a.Name,
                                  ComName = ComLibs.Name,
                                  t.ProbType,
                                  t.ProbDetail,
                                  t.Status
                              };
        TicketList = TicketListQuery.ToList();
        return View(TicketList);
    }
