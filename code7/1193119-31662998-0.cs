    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(JobVM jobVM) {
    
          // validate VM
          // ...
          // the following code should be in the Service Layer but I'll write it below to simplify
          // get job from DB
          var job = db.Jobs.SingleOrDefault(p => p.Id == jobVM.Id);
    
          job.JobTypesID = jobVM.JobTypesID;
    
          job.JobStatusID = jobVM.StatusId;
    
          db.SaveChanges();
          return RedirectToAction("Index");
     }
