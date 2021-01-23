        public ActionResult Index(JobSeekerViewModel jobSeeker)
        {
            return RedirectToAction("Details", new {id = jobSeeker });
        }
        public ActionResult Details()
        {
            JobSeekerViewModel jobSeeker = (JobSeekerViewModel)RouteData.Values["id"];
            return View(jobSeeker);
        }
