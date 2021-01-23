    public static async Task<bool> AddMethod(string solutionPath)
    {
        var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync(solutionPath);
        ClassDeclarationSyntax cls = SyntaxFactory.ClassDeclaration("someclass");
        foreach (var projectId in solution.ProjectIds)
        {
            var project = solution.GetProject(projectId);
            foreach (var documentId in project.DocumentIds)
            {
                Document doc = project.GetDocument(documentId);
                var root = await doc.GetSyntaxRootAsync();
                var firstClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
                if (firstClass == null)
                    return true;
                var newRoot = root.ReplaceNode(firstClass, cls);
                doc = doc.WithText(newRoot.GetText());
                //Persist your changes to the current project
                project = doc.Project;
            }
            //Persist the project changes to the current solution
            solution = project.Solution;
        }
        //Finally, apply all your changes to the workspace at once.
        var abc = workspace.TryApplyChanges(solution);
        return true;
    }
