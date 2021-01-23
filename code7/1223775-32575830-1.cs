    public ActionResult EditSingles(int ID)
    {
      // Initialize your view model
      EditSinglesVM model = new EditSinglesVM();
      // Populate the SelectList's
      ConfigureViewModel(model);
      return View(model);
    }
    private void ConfigureViewModel(EditSinglesVM model)
    {
      model.PlayerList = db.Golfers().Select(g => new SelectListItem
      {
        Value = g.PlayerID.ToString(),
        Text = string.Format("{0} {1}", g.FirstName, g.Surname)
      });
      model.CourseList = db.Courses().Select(c => new SelectListItem
      {
        Value = g.CourseID.ToString(),
        Text = g.CourseName
      });
    }
