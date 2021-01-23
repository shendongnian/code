    public ActionResult GetPage(int page, int pageSize)
    {
        var dbContext = new DbContext();
        int count=(from j in dbContext.Jobs select j).Count();
        var jobs = dbContext.Jobs.OrderBy(job=>job.Id).skip(page * pageSize).Take(pageSize);
        return Json(new { jobs = jobs, total = count },JsonRequestBehavior.AllowGet );
    }
