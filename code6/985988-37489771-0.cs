    // Get EnvDTE / DTE.
    DTE dte = (DTE) GetService(typeof(DTE));
    // Get the current solution.
    var solution = dte.Solution;
    // Save the solution file.
    if(!solution.Saved)
        solution.SaveAs(solution.FullName);
            
    // Save the project files within the solution.
    for(int i = 1; i <= solution.Projects.Count; i++)
    {
        var project = solution.Projects.Item(i);
        if (!project.Saved)
            project.Save();
        // Save all the files and items within the project.
        for(int j = 1; j <= project.ProjectItems.Count; j++)
        {
            var item = project.ProjectItems.Item(j);
            if (!item.Saved)
                item.Save();
        }
    }
