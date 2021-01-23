    Workspace ws = null; //Normally you'd get access to the VisualStudioWorkspace here.
    var currentSolution = ws.CurrentSolution;
    foreach (var projectId in currentSolution.ProjectIds)
    {
        var project = currentSolution.GetProject(projectId);
        foreach (var documentId in project.DocumentIds)
        {
            Document doc = project.GetDocument(documentId);
            var root = await doc.GetSyntaxRootAsync();
            //Rewrite your root here
            var rewrittenRoot = RewriteSyntaxRoot(root);
            //Save the changes to the current document
            doc = doc.WithSyntaxRoot(root);
            //Persist your changes to the current project
            project = doc.Project;
        }
        //Persist the project changes to the current solution
        currentSolution = project.Solution;
    }
    //Now you have your rewritten solution. You can emit the projects to disk one by one if you'd like.
