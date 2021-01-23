    public ActionResult _ReportingMenu()
    {
        var DashboardList = GetAllDashboards();
        var dropdownData = DashboardList
            .Select(d => new SelectListItem
            {
                Text = d.Name, //Need to apply the correct text field here
                Value = d.Id.ToString() //Need to apply the correct value field here
            })
            .ToList();
        var model = new DashboardViewModel
        {
           Data = dropdownData 
        };
        return View(model);
    }
