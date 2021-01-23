    [HttpPost]
    public ActionResult WeeklyMonitoring(FormCollection form)
    {
        string week = form["Weeks"];           
    
        ProjectResourceManagerService pr = new ProjectResourceManagerService(new ModelStateWrapper(this.ModelState));
    
        List<string> wl = pr.FetchWeeks(DateTime.Now.Year);
        ViewBag.Weeks =   wl.Select(m => new SelectListItem { Text = m, Value = m, Selected = m == week });
        return View();
    }
