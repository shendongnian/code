    public ActionResult Index()
    {
        string employerIdText = SessionPersister.Email_ID;
        int employerId = int.Parse(employerIdText);
        var jobs = db.Job_Det
            .OrderByDescending(j => j.Job_ID)
            .Where(x => x.Employeer_ID == employerId)
            .ToList();
        return View(jobs);
    }
