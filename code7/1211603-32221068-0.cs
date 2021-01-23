    [HttpPost]
    public ActionResult Index(string sortOrder, int? page, DateTime? datePicker)
    {
        ViewBag.CurrentSort = sortOrder;
        ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        DateTime userSelectedDate = DateTime.Parse(Request["datePicker"]);
        var startDate = userSelectedDate.Date;
        var endDate = startDate.AddDays(1);
        var applications = from s in db.ElmahErrors
                       where s.TimeUtc >= startDate && s.TimeUtc < endDate
                       select s;
        switch (sortOrder)
        {
            default:
                applications = applications.OrderByDescending(x => x.TimeUtc);
                break;
        }
        int pageSize = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["DefaultPageSize"]);
        int pageNumber = (page ?? 1);
        return View(applications.ToPagedList(pageNumber, pageSize));
    }
