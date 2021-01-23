    IVsTextManager textManager = (IVsTextManager)GetService(typeof(SVsTextManager));
    IVsTextView textView = null;
    textManager.GetActiveView(1, null, out textView);
    IComponentModel componentModel =(IComponentModel)GetService(typeof(SComponentModel));
    Microsoft.VisualStudio.Text.Editor.IWpfTextView textView =  componentModel.GetService<IVsEditorAdaptersFactoryService>().GetWpfTextView(textView);
    textView.Caret.MoveTo(/*lots of overrides*/);
