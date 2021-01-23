    public ActionResult Details(int ID)
    {
        Employee employee = db.Employees.Where(e => e.EMT_EmployeeID == ID).FirstOrDefault();
        if (employee == null)
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        else
        {
            var data = new { name = employee.FullName, department = employee.Department };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
