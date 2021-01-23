    [HttpPost]
    public ActionResult ChooseType(LeaveTypeVM model)
    {
        if (!ModelState.IsValid)
        {
            model.LeaveTypeList = .... // as per GET method
        }
        return RedirectToAction("Create", new { leaveType = model.SelectedLeaveType });
