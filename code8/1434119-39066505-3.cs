        // GET: Jobs/Create
        public ActionResult Create()
        {
            JobViewModel job = new JobViewModel();
            return View(job);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobViewModel jobvm)
        {
            if (Request.Form["addmachine"] != null)
            {
                jobvm.AddMachine();
                ModelState.Remove("NewMachineName");
                ModelState.Remove("NewMachineType");
                ModelState.Remove("NewMachineBrand");
                return View(jobvm);
            }
            if (ModelState.IsValid)
            {
                Job job = jobvm.GetJob();
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobvm);
        }
