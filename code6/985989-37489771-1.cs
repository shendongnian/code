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
        // Check if this item is Solution Folder.
        if (project.Kind == "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}")
                    continue;
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
