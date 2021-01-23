    public JsonResult Index()
    {
        var employees = this.employeeManager.EmployeeList();
        
        var eventList = employees.Months.Select(e => new 
                        {
                            id = e.Id,
                            firstName = e.Name,
                            dateFrom = e.DateFrom,
                            dateTo = e.DateTo,
                        }).ToList();
        
        return Json(eventList, JsonRequestBehavior.AllowGet);
    }
