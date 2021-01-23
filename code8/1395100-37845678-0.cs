    public ActionResult Index(string searchName)
    {
          // Current projects
          var projects = db.Projects;
          // Filter down if necessary
          if(!String.IsNullOrEmpty(searchName))
          {
              projects = projects.Where(p => p.projectName.Contains(searchName) || p.projectName.Contains(searchName));
          }
          // Pass your list out to your view
          return View(projects.ToList());
      }
