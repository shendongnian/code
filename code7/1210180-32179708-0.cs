    foreach (var projectId in solution.ProjectIds)
    {
        var project = solution.GetProject(projectId);
        foreach (var documentId in project.DocumentIds)
        {
            Document document = project.GetDocument(documentId);
            if (document.SourceCodeKind != SourceCodeKind.Regular)
                continue;
            var doc = document;
            foreach (var rewriter in rewriters)
            {
                doc = await rewriter.Rewrite(doc);
                       
            }
            if (doc != document)
            {
                project = doc.Project;
            }                    
        }
        solution = project.Solution;
    }
    msWorkspace.TryApplyChanges(solution);
