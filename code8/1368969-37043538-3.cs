    [HttpPost]
    [RBAC]
    public async Task<ActionResult> Create(UserProgramsViewModel model, FormCollection formCollection)
    {
        var list = new List<DaysViewModel>();
        foreach(var key in formCollection.AllKeys.Where(x => x.Contains("Days")))
            list.Add(new DaysViewModel { Id = formCollection[key] == "on" ? 1 : 0, DayName = key.Replace("Days", "")} );
        model.Days = list;
         //other stuff
    }
