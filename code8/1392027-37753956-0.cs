    var originalSolution = ...;
    var rewrittenSolution = originalSolution;
    foreach (var projectId in originalSolution.ProjectIds)
    {
        var projectToRewrite = rewrittenSolution.GetProject(projectId);
        // update projectToRewrite here
        rewrittenSolution = projectToRewrite.Solution;
    }
    workspace.TryApplyChanges(rewrittenSolution);
