    [HttpPost]
    [RBAC]
    public async Task<ActionResult> Create(UserProgramsViewModel model, FormCollection formCollection)
    {
        model.Days = new List<DaysViewModel>();
        foreach(var key in formCollection.AllKeys.Where(x => x.Contains("Days")))
            model.Days.Add(new DaysViewModel { Id = formCollection[key] == "on" ? 1 : 0, DayName = key.Replace("Days", "")} );
         //other stuff...
    }
