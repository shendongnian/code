    Microsoft.CodeAnalysis.Solution solution = CreateUnitTestBoilerplateCommandPackage.VisualStudioWorkspace.CurrentSolution;
    DocumentId documentId = solution.GetDocumentIdsWithFilePath(inputFilePath).FirstOrDefault();
    var document = solution.GetDocument(documentId);
    SyntaxNode root = await document.GetSyntaxRootAsync();
    SemanticModel semanticModel = await document.GetSemanticModelAsync();
