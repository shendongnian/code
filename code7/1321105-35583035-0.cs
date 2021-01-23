    public JsonResult GetEmployees(int[] EmployeeId)
            {
                var dbs = new dbContext();
    
                if (EmployeeId != null)
                {                
                    var EmpList = dbs.Employees.Where(EmployeeId.Contains(e.EmployeeId))
                    .Select(e => new
                    {
                        EmployeeId = e.EmployeeId,
                        Name = e.EmployeeName,
                        Job = e.Job.JobName,
                        Currency = e.Currency.CurrencyName,
                        Amount = e.Amount
                    }).Where(o => o.EmployeeId != emp);
    
                    return Json(EmpList, JsonRequestBehavior.AllowGet);               
                }
    
                return null;
            }
