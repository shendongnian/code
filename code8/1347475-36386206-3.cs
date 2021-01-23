    public ActionResult displaycustomer()
    {
        // Get data from database
        List<View_VisitorsForm> objvisitlist = (from v in db.View_VisitorsForm select v).ToList(); 
        // Create a new viewmodel and fill it with the data you want displayed
        VisitorsViewModel viewmodel = new VisitorsViewModel
        {
            FromDate = DateTime.Now.AddDays(-7), //(some default value)
            ToDate = DateTime.Now,               //(some default value)
            Visits = new List<VisitViewModel>()
        };
        foreach (View_VisitorsForm visit in objvisitlist)
        {
            viewmodel.Visits.Add(new VisitViewModel
            {
                CustomerName = visit.CustomerName,
                PoVisit = visit.POVisit,
                StartTime = visit.StartTime,
                EndTime  = visit.EndTime,
                Employee = visit.Employee
            }
        }
        // return a ViewResult with the viewmodel 
        return View(viewmodel);
    } 
