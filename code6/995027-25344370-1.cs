    [AllowAnonymous]
    [HttpGet]
    public ActionResult Index(string projectName)
    {
        if (string.IsNullOrWhiteSpace(projectName))
        {
            // return your empty view
        }
        int projectId;
        if (int.TryParse(projectName, out projectId))
        {
            projectName = GetProjectNameFromDatabase(projectId);
            return RedirectToAction("Index", new { projectName });
        }
        // return your view with your model
    }
