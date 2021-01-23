    public ActionResult method(int? id)
    {
      IEnumerable<Project> projects = repository.FindAsync(Identity.User.Id);
      MyViewModel model = new MyViewModel()
      {
        SelectedProject = projects.FirstOrDefault(p => p.Id == id),
        ProjectList = new SelectList(projects, "Id", "Name")
      };
      return View(model);
    }
