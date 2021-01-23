    [HttpPost]
    [RBAC]
    public async Task<ActionResult> Create(UserProgramsViewModel model, FormCollection formCollection)
    {
        var list = new List<DaysViewModel>();
        foreach(var key in formCollection.AllKeys.Where(x => x.Contains("Days")))
        {
            var temp = key.Replace("Days", "");
            if (formCollection[temp] == "on")
                list.Add(new DaysViewModel { Id = 1, DayName = temp });
        }
        model.Days = list;
         //other stuff
    }
