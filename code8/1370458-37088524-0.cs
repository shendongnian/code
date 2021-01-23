    public ActionResult Create(int projectId)
    {
        Application model = new Application()
        {
            ProjectId = projectId 
        };
        return View(model);
    }
