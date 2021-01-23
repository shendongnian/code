    @using (Html.BeginForm("Index", "Projects", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        var allProjects = ViewData["allProjects"] as List<Project>;
        var allProjectStatuses = ViewBag.ProjectStatus as List<ProjectStatus>;
        foreach (var project in allProjectStatuses)
        {
            <div>
                Html.RenderPartial("Projects", allProjects.Where(x => x.ProjectStatus.Name == project));
            </div>
        }
    }
