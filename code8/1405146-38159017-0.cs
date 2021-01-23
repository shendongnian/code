    public JsonResult GetEmployeesData()
    {
         using (TrainingDBEntities db = new TrainingDBEntities())
         {
               var emps = db.Employees.ToList();
               return new JsonResult { Data = emps, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
         }
    }
