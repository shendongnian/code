    private IEnumerable<Project> GetSolutionFolderProjects(Project project)
    {
        List<Project> projects = new List<Project>();
        var y = (project.ProjectItems as ProjectItems).Count;
        for(var i = 1; i <= y; i++)
        {
            var x = project.ProjectItems.Item(i).SubProject;
            var subProject = x as Project;
            if (subProject != null)
            {
              //Carried out work and added projects as appropriate
            }
        }
        return projects;
    }
