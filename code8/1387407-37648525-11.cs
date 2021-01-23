    public ActionResult Create(int leaveType)
    {
        var employee = DataAccess.GetEmployee(@User.Identity.Name);
        var rule = RuleAccess.GetEmployeeRules(employee).Where(x => x.ID == leaveType).FirstOrDefault();
        if (rule == null)
        {
            // Throw exception or redirect to an error page
        }
        var model = new LeaveApplicationViewModels();
        ....
        return View(model);
    }
