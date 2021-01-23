    private IVsEditorAdaptersFactoryService GetEditorAdaptersFactoryService()
        {
            IComponentModel componentModel =(IComponentModel)GetService(typeof(SComponentModel));
            return componentModel.GetService<IVsEditorAdaptersFactoryService>();
        }   
    private Microsoft.VisualStudio.Text.Editor.IWpfTextView GetTextView()
    {
        IVsTextManager textManager = (IVsTextManager)GetService(typeof(SVsTextManager));
        if (textManager == null)
            return null;
        IVsTextView textView = null;
        textManager.GetActiveView(1, null, out textView);
        if (textView == null)
            return null;
        return GetEditorAdaptersFactoryService().GetWpfTextView(textView);
    }
    //code to get the doc
    Microsoft.VisualStudio.Text.Editor.IWpfTextView textView = GetTextView();
    if (textView != null)
    {
        SnapshotPoint caretPosition = textView.Caret.Position.BufferPosition;
        Document document = caretPosition.Snapshot.GetOpenDocumentInCurrentContextWithChanges();
    //do stuff with Roslyn Document
    }
