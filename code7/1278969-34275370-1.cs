    public ActionResult SaveSettings(ProjectPlan projectPlan)
    {
         var plan = this._dc.ProjectPlans.Single(a => a.Id == projectPlan.Id);
         plan.StartDate = DateTime.ParseExact(projectPlan.ShortDateTime, projectPlan.DateFormat, null);
         this._dc.SaveChanges();
    }
