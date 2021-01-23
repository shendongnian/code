    internal sealed class TextAdornment
        {
            private readonly ITextDocumentFactoryService textDocumentFactory;
            private ITextDocument TextDocument;
            //...    
            public TextAdornment(IWpfTextView view, ITextDocumentFactoryService textDocumentFactory)
            {
                //...
                this.textDocumentFactory = textDocumentFactory;
                //...
            }
            
    	 internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
            {
                var res = this.textDocumentFactory.TryGetTextDocument(this.view.TextBuffer, out this.TextDocument);
                if (res)
                {
                    //this.TextDocument.FilePath;
                }
                else
                {
                    //ERROR
                }
            }
        }
