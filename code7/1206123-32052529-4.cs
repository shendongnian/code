    public ActionResult Index(FormCollection form)
    {
        using (DatabaseLayer db = new DatabaseLayer())
        {
            ViewData["projectList"] = new SelectList(db.GetConsultantProjects(Constants.CurrentUser(User.Identity.Name)), "ProjectId", "ProjectName");
            ViewData["allProjects"] = db.GetAllProjects().OrderByDescending(x => x.StartDate).ToList();
       
            // Set ViewData allStatuses to store all project statuses from DB
            ViewData["allStatuses"] = db.GetAllProjectStatuses().ToList();
            if (form != null && form.AllKeys.Length > 0)
            {
                var projects = from x in form.AllKeys where x.Length >= 3 && x.Substring(0, 3) == "cb-" && form[x] == "true,false" select new Guid(x.Substring(3));
                db.UpdateConsultantProjectMemberships(Constants.CurrentUser(User.Identity.Name), projects);
                ViewData["posted"] = true;
            }
        }
        return View();
    }
