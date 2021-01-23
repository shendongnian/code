    [HttpPost]
    public JsonResult Get([DataSourceRequest] DataSourceRequest request)
    {
    var employees = db.Employees.Where(e => e.IsActive);
    var employeeViewModel = employees.Project().To<EmployeeViewModel>();
    var results = employeeViewModel.ToDataSourceResult(request);
    return Json(results);
    }
    
