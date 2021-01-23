    [HttpPost]
    public ViewResult Unassigned(AssignPatrolViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.PatrolList = new SelectList(db.Patrols, "PatrolId", "PatrolName");
            return View(model);
        }
        // Get selected ID's
        IEnumerable<int> selected = model.Members.Where(m => m.IsSelected).Select(m => m.MemberId);
        // Get matching data models
        var members = db.Person.Where(p => selected.Contains(p.PID)); // modify to suit
        // loop each each member, update its PatrolId to the value of model.SelectedPatrol
        // save and redirect
    }
