    private static readonly Guid CSharpProjectTypeGuid = Guid.Parse(PrjKind.prjKindCSharpProject);
    private uint _trackDocumentsEventsCookie;
    protected override void Initialize()
    {
        base.Initialize();
        IVsTrackProjectDocuments2 trackDocuments2 = serviceProvider.GetTrackProjectDocuments2();
        trackDocuments2.AdviseTrackProjectDocumentsEvents(this, out _trackDocumentsEventsCookie);
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_trackDocumentsEventsCookie != 0)
            {
                var serviceProvider = this.AsVsServiceProvider();
                IVsTrackProjectDocuments2 trackDocuments = serviceProvider.GetTrackProjectDocuments2();
                trackDocuments.UnadviseTrackProjectDocumentsEvents(_trackDocumentsEventsCookie);
                _trackDocumentsEventsCookie = 0;
            }
        }
        base.Dispose(disposing);
    }
    public int OnAfterAddFilesEx(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDFILEFLAGS[] rgFlags)
    {
        /* need to make the following alterations:
            *  1. set the Build Action of *.g and *.g3 to Antlr3
            *  2. set the Build Action of *.g4 to Antlr4
            *  3. set the Custom Tool of *.g, *.g3, and *.g4 to MSBuild:Compile
            *  4. set the Custom Tool Namespace of *.g4 to $(RootNamespace) + relative folder path
            */
        for (int i = 0; i < cProjects; i++)
        {
            IVsProject project = rgpProjects[i];
            int projectFiles = (i == cProjects - 1) ? cFiles : rgFirstIndices[i + 1];
            projectFiles -= rgFirstIndices[i];
            if (!IsCSharpProject(project))
                continue;
            for (int j = 0; j < projectFiles; j++)
            {
                string currentFile = rgpszMkDocuments[rgFirstIndices[i] + j];
                if (string.IsNullOrEmpty(currentFile))
                    continue;
                bool grammarFile =
                    currentFile.EndsWith(".tokens", StringComparison.OrdinalIgnoreCase)
                    || currentFile.EndsWith(".g", StringComparison.OrdinalIgnoreCase)
                    || currentFile.EndsWith(".g3", StringComparison.OrdinalIgnoreCase)
                    || currentFile.EndsWith(".g4", StringComparison.OrdinalIgnoreCase);
                if (grammarFile)
                {
                    OnAfterAddedGrammarFile(project, currentFile);
                }
            }
        }
        return VSConstants.S_OK;
    }
    private static bool IsCSharpProject(IVsProject project)
    {
        IVsAggregatableProject aggregatableProject = project as IVsAggregatableProject;
        if (aggregatableProject == null)
            return false;
        string guidsString = null;
        if (ErrorHandler.Failed(ErrorHandler.CallWithCOMConvention(() => aggregatableProject.GetAggregateProjectTypeGuids(out guidsString))))
            return false;
        if (string.IsNullOrWhiteSpace(guidsString))
            return false;
        string[] guids = guidsString.Split(';');
        foreach (var guidString in guids)
        {
            Guid guid;
            if (Guid.TryParse(guidString, out guid) && guid == CSharpProjectTypeGuid)
                return true;
        }
        return false;
    }
    private void OnAfterAddedGrammarFile(IVsProject project, string currentFile)
    {
        int found;
        VSDOCUMENTPRIORITY[] priority = new VSDOCUMENTPRIORITY[1];
        uint itemId;
        if (ErrorHandler.Failed(project.IsDocumentInProject(currentFile, out found, priority, out itemId)))
            return;
        if (found == 0 || priority[0] != VSDOCUMENTPRIORITY.DP_Standard)
            return;
        string desiredItemType = "Antlr3";
        if (string.Equals(Path.GetExtension(currentFile), ".tokens", StringComparison.OrdinalIgnoreCase))
            desiredItemType = "AntlrTokens";
        else if (string.Equals(Path.GetExtension(currentFile), ".g4", StringComparison.OrdinalIgnoreCase))
            desiredItemType = "Antlr4";
        IVsHierarchy hierarchy = project as IVsHierarchy;
        if (hierarchy != null)
        {
            object browseObject = null;
            PropertyDescriptorCollection propertyDescriptors = null;
            int hr = ErrorHandler.CallWithCOMConvention(() => hierarchy.GetProperty(itemId, (int)__VSHPROPID.VSHPROPID_BrowseObject, out browseObject));
            if (ErrorHandler.Succeeded(hr))
                propertyDescriptors = TypeDescriptor.GetProperties(browseObject);
            object obj;
            hr = hierarchy.GetProperty(itemId, (int)__VSHPROPID4.VSHPROPID_BuildAction, out obj);
            if (ErrorHandler.Succeeded(hr))
            {
                string buildAction = obj != null ? obj.ToString() : null;
                if (string.IsNullOrWhiteSpace(buildAction) || string.Equals(buildAction, "None", StringComparison.OrdinalIgnoreCase))
                {
                    hr = ErrorHandler.CallWithCOMConvention(() => hierarchy.SetProperty(itemId, (int)__VSHPROPID4.VSHPROPID_BuildAction, desiredItemType));
                }
            }
            if (ErrorHandler.Failed(hr) && propertyDescriptors != null)
            {
                PropertyDescriptor itemTypeDescriptor = propertyDescriptors["ItemType"] ?? propertyDescriptors["BuildAction"];
                if (itemTypeDescriptor != null)
                {
                    obj = itemTypeDescriptor.GetValue(browseObject);
                    string buildAction = (string)itemTypeDescriptor.Converter.ConvertToInvariantString(obj);
                    if (string.IsNullOrWhiteSpace(buildAction) || string.Equals(buildAction, "None", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            obj = itemTypeDescriptor.Converter.ConvertFromInvariantString(desiredItemType);
                            itemTypeDescriptor.SetValue(browseObject, obj);
                        }
                        catch (NotSupportedException)
                        {
                        }
                    }
                }
            }
            if (propertyDescriptors != null)
            {
                PropertyDescriptor customToolDescriptor = propertyDescriptors["CustomTool"];
                if (customToolDescriptor != null)
                {
                    obj = customToolDescriptor.GetValue(browseObject);
                    string customTool = customToolDescriptor.Converter.ConvertToInvariantString(obj);
                    if (string.IsNullOrWhiteSpace(customTool))
                    {
                        try
                        {
                            obj = customToolDescriptor.Converter.ConvertToInvariantString("MSBuild:Compile");
                            customToolDescriptor.SetValue(browseObject, obj);
                        }
                        catch (NotSupportedException)
                        {
                        }
                    }
                }
                PropertyDescriptor customToolNamespaceDescriptor = propertyDescriptors["CustomToolNamespace"];
                if (customToolNamespaceDescriptor != null)
                {
                    object defaultNamespace;
                    hr = hierarchy.GetProperty(itemId, (int)__VSHPROPID.VSHPROPID_DefaultNamespace, out defaultNamespace);
                    if (ErrorHandler.Succeeded(hr) && !string.IsNullOrEmpty(defaultNamespace as string))
                    {
                        obj = customToolNamespaceDescriptor.GetValue(browseObject);
                        string customToolNamespace = customToolNamespaceDescriptor.Converter.ConvertToInvariantString(obj);
                        if (string.IsNullOrWhiteSpace(customToolNamespace))
                        {
                            try
                            {
                                obj = customToolNamespaceDescriptor.Converter.ConvertToInvariantString(defaultNamespace);
                                customToolNamespaceDescriptor.SetValue(browseObject, obj);
                            }
                            catch (NotSupportedException)
                            {
                            }
                        }
                    }
                }
            }
        }
    }
