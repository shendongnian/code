     public ActionResult Index()
    {
        var EmployeerId = SessionPersister.Email_ID;
        //Convert.ToInt32(EmployeerId);
       int EmpId=int.Parse(EmployeerId);
        db.Job_Det.OrderByDescending(j => j.Job_ID).ToList().Where(x => x.Employeer_ID = EmpId);
        return View();
    }
