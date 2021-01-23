    <#@ import namespace="System.Linq" #>
    <#
    var dte = (DTE)hostServiceProvider.GetService(typeof(DTE));
    var project = GetProject(dte.Solution, "ProjectName");
    #>
    <#+
    public static Project GetProject(Solution solution, string name)
	{
		var project = GetProject(solution.Projects.OfType<Project>(), name);
		if (project == null)
		{
			throw new Exception($"Project {name} not found in solution");
		}
		return project;
	}
	public static Project GetProject(IEnumerable<Project> projects, string name)
	{
		foreach (Project project in projects)
		{
			var projectName = project.Name;
			if (projectName == name)
			{
				return project;
			}
			else if (project.Kind == EnvDTE80.ProjectKinds.vsProjectKindSolutionFolder)
			{
				var subProjects = project
					.ProjectItems
					.OfType<ProjectItem>()
					.Where(item => item.SubProject != null)
					.Select(item => item.SubProject);
				var projectInFolder = GetProject(subProjects, name);
				if (projectInFolder != null)
				{
					return projectInFolder;
				}
			}
		}
		return null;
	}
    #>
