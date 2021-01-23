    var dteService = Package.GetGlobalService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
    if (dteService == null)
    {
       Debug.WriteLine("");
       return;
    }
    DocumentService documentService = Package.GetGlobalService(typeof(DocumentService)) as DocumentService;
    if (documentService == null)
          return;
    string fullName = dteService.ActiveDocument.FullName;
    IWorkItemTrackingDocument activeDocument = documentService.FindDocument(fullName, null);
    if (activeDocument == null || !(activeDocument is IResultsDocument))
                 return;
