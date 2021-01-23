       public ActionResult AddJob(string userCode)
    {
        var jobs = jobsClient.GetAlljobs();
        var alljobsCode = (from s in jobs select s.jobCode).ToList();
        var usersJobs = (from s in db.UserJobs
                                   where s.userCode == userCode
                                   select s.jobCode).ToList();
        var jobsNeeded = alljobsCode.Except(usersJobs);
        List<UserJobsDTO> list = listBuilder(jobs, jobsNeeded);
        ViewBag.jobCode = new SelectList(list, "jobCode", "jobDescription");
    //    var model = new UserJob { userCode = userCode };
        return View("AddJob", usersJobs );
    }
