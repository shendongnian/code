    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class TextAdornmentTextViewCreationListener : IWpfTextViewCreationListener
    {
        [Import]
        public ITextDocumentFactoryService textDocumentFactory { get; set; }
    
        //...
        public void TextViewCreated(IWpfTextView textView)
        {
            new TextAdornment(textView, textDocumentFactory);
        }
    }
