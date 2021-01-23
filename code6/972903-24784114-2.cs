    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType("csharp")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    class TextViewCreationListener : IVsTextViewCreationListener {
    	internal readonly IVsEditorAdaptersFactoryService _adaptersFactory;
    
        [Import] internal IContentTypeRegistryService ContentTypeRegistryService = null;
    
    	[ImportingConstructor]
    	public TextViewCreationListener(IVsEditorAdaptersFactoryService adaptersFactory) {
    		_adaptersFactory = adaptersFactory;
    	}
    
    	#region IVsTextViewCreationListener Members
    
    	public void VsTextViewCreated(VisualStudio.TextManager.Interop.IVsTextView textViewAdapter) {
    		var textView = _adaptersFactory.GetWpfTextView(textViewAdapter);
    
            var myContent = ContentTypeRegistryService.GetContentType(MyContentType);
            if(myContent == null)
            {
                ContentTypeRegistryService.AddContentType(MyContentType, new[] {"csharp"});
                myContent = ContentTypeRegistryService.GetContentType(MyContentType);
            }
            
            // some kind of check if the content type is not already MyContentType. 
            textView.TextBuffer.ChangeContentType(myContent, null);
    	}
    
    	#endregion
    }
