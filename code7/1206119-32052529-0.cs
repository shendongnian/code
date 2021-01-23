    @using (Html.BeginForm("Index", "Projects", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        var allProjects = ViewData["allProjects"] as List<Project>;
        foreach (var project in allProjects)
        {
            <div>
                Html.RenderPartial("Projects", allProjects.Where(x => x.ProjectStatu.Name == project.ProjectStatus.Name));
            </div>
        }
    }
