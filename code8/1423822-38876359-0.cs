    if (Scope == EnvDTE.vsBuildScope.vsBuildScopeSolution)
    {
        errorListProvider.Tasks.Clear();
        DTE2 dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
        var sol = dte2.Solution;
        var projs = sol.Projects;
        foreach(var proj in sol)
        {
             var project = proj as Project;
             if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
             {
                 var innerProjects = GetSolutionFolderProjects(project);
                 foreach(var innerProject in innerProjects)
                 {
                     //carry out actions here.
                 }
             }
        }
    }
