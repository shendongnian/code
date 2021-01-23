    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult PreRegister(EventPreRegisterViewModel viewModel)
    {
        // Find the event
        var eventSel = db.Events.Find(viewModel.EventId);
        // Remove previous instructors
        foreach (var previousInstructor in eventSel.InstructorEvents)
        {
            db.InstructorEvents.Remove(previousInstructor);
        }
        foreach (var model in viewModel.InstructorRegisterListViewModels)
        {
            var newInstructorEvent = new InstructorEvent { EventId = eventSel.EventId, InstructorId = model.InstructorId, AttendanceId = model.AttenanceId };
            db.InstructorEvents.Add(newInstructorEvent);
        }
        // Save new club interests           
        db.SaveChanges();
        return RedirectToAction("Index");
    }
