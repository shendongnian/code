    public ActionResult ChooseType()
    {
        var employee = DataAccess.GetEmployee(@User.Identity.Name);
        var rules = RuleAccess.GetEmployeeRules(employee);
        var model = new LeaveTypeVM()
        {
            LeaveTypeList = new SelectList(rules, "ID", "TypeDetail")
        };
        return View(model);
    }
