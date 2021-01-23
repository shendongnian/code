    void AddProjectReference(
        EnvDTE.Project wixProject,
        EnvDTE.Project projectToReference)
    {
        var references = wixProject.ProjectItems
            .Cast<EnvDTE.ProjectItem>()
            .Select(x => x.Object)
            .OfType<VSLangProj.References>()
            .FirstOrDefault();
        if (references != null)
        {
            references.AddProject(projectToReference);
        }
    }
