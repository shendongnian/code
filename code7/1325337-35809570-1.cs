    public ViewResult Unassigned()
    {
      var model = new AssignPatrolViewModel
      {
          PatrolList = new SelectList(db.Patrols, "PatrolId", "PatrolName"), // modify to suit
          Members = repository.SelectAllUnassigned().ToList()
      };
      return View(model);
    }
