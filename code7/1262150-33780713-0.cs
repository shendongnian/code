    public ActionResult Index(string fromDateFilter = "")
    {
        if (fromDate != "")
        {
            DateTime fromDateAsDateTime = DateTime.Parse(fromDateFilter);
            Does stuff here...
        }
    }
