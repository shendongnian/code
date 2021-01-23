    // GET: Expenses
    [Authorize]
    public ActionResult Index()
    {
        var expenses = db.Expenses.Where(e => e.UserId == User.Identity.GetUserId());
        return View(expenses.ToList());
    }
