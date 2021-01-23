    // Define other methods and classes here
    public static ProjectListItemViewModel CreateViewModel(P.Project project)
    {
    	var rex = new Regex(@"<[^>]+>|&nbsp;");
    	var expected = rex.Replace(project.ExpectedResult ?? string.Empty, string.Empty).Trim();
    
    	return new ProjectListItemViewModel
    	{
    		Id = project.Id,
    		ExpectedResult = expected.Length > 100 ? expected.Length.Substring(0, 100) : expected,
    		Initiator = project.Initiator.FullName,
    		Status = project.Status.Name,
    		ProjectManager = project.ProjectManager != null ? project.ProjectManager.FullName : "",
    	};
    }
