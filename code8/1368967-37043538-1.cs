    [HttpPost]
    [RBAC]
    public async Task<ActionResult> Create(UserProgramsViewModel model, FormCollection formCollection)
    {
        var list = new List<DaysViewModel>();
        foreach(var key in formCollection.AllKeys.Where(x => x.Contains("Days")))
            if (formCollection[key] == "on")
                list.Add(new DaysViewModel { Id = 1, DayName = key.Replace("Days", "")} );
        model.Days = list;
         //other stuff
    }
