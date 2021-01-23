    public JsonResult Index()
    {
        var employees = this.employeeManager.EmployeeList();
        
        var eventList = employees.Select(e => new 
                        {
                            id = e.Mounts.Id,
                            firstName = e.Mounts.Name,
                            dateFrom = e.Mounts.DateFrom,
                            dateTo = e.Mounts.DateTo,
                        }).ToList();
        
        return Json(eventList, JsonRequestBehavior.AllowGet);
    }
