    public ActionResult Index(string sortOrder, string searchString, int pageSize, int? page)
    {
        if (searchString != null)
        {
            page = 1;
        }
        // this query should be taking into account the values of sortOrder and searchString?
        var users = from s in db.Users.Include(u => u.CustomerProject).Include(u => u.Service).Include(u => u.Customer) select s;
        TimeReportVM model = new TimeReportVM()
        {
            SortOrder = sortOrder,
            SearchString = searchString,
            PageSize = pageSize,
            PageSizeList = new SelectList(new int[]{ 10, 20, 100 }),
            Users = users.ToPagedList(page ?? 1, pageSize);
        };
        return View(model);
    }
