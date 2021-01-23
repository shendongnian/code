    [HttpPost]
    public ActionResoult MyAction(MyViewModel model)
    {
        var adminId = model.SelectedAdmin;
        var bmId = model.SelectedBM;
        // rest of code
    }
