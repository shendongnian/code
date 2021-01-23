    public JsonResult Index()
    {
        var employees = this.employeeManager.EmployeeList();
               
        var eventList = from e in employees
                        select new
                        {
                            id = e.Mounts.Id,
                            firstName = e.Mounts.Name,
                            dateFrom = e.Mounts.DateFrom,
                            dateTo = e.Mounts.DateTo,
                        };
        
        return Json(eventList, JsonRequestBehavior.AllowGet);
    }
