    public JsonResult Index()
    {
        var employees = this.employeeManager.EmployeeList();
               
        var employeesList = employees.Select(e => new 
                        {
                            id = e.Id,
                            firstName = e.Name,
                            eventsList = e.Months.Select(o => new {
                                 id = o.Id,
                                 firstName = o.Name,
                                 dateFrom = o.DateFrom,
                                 dateTo = o.DateTo
                            }).ToList()
                        }).ToList();
        
        return Json(employeesList, JsonRequestBehavior.AllowGet);
    }
