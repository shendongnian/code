    public class DocumentContainer
    {
        public Action ProtectedDeferredExecution { get; set; }
        public DocumentContainer(Action deferred)
        {
            ProtectedDeferredExecution = deferred;
        }
    }
    public partial class ThisAddIn
    {
        private Dictionary<Document, DocumentContainer> DocumentContainerDict { get; set; }
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            DocumentContainerDict = new Dictionary<Document, DocumentContainer>();
            Application.WindowActivate += application_WindowActivate;
            Application.DocumentOpen += application_DocumentOpen;
            Application.DocumentBeforeClose += application_DocumentClose;
        }
        private void application_DocumentOpen(Document doc)
        {
            // define code that is unsafe when document is protected
            Action initialization = () =>
            {
                doc.ContentControls.Add(
                    WdContentControlType.wdContentControlRichText,
                    doc.Range(doc.Content.Start, doc.Content.End - 1));
            };
            // if the current window isn't "protected", able to execute the unsafe code
            if (Application.ActiveProtectedViewWindow == null)
            {
                initialization();
                initialization = null;
            }
            // send either the unsafe delegate or null to the constructor
            DocumentContainerDict.Add(doc, new VersioningDocumentContainer(initialization));
        }
        private void application_WindowActivate(Document doc, Window wn)
        {
            // skip execution if the window is still protected or isn't the view we want
            if (wn.View.Type != WdViewType.wdPrintView || Application.ActiveProtectedViewWindow != null)
            {
                return;
            }
            DocumentContainer container;
            // find the document container, if any, and the delegate to execute
            if (DocumentContainerDict.TryGetValue(doc, out container)
                && container.ProtectedDeferredExecution != null)
            {
                container.ProtectedDeferredExecution();
                container.ProtectedDeferredExecution = null;
            }
        }
        // clean up
        private void application_DocumentClose(Document doc, ref bool cancel)
        {
            DocumentContainerDict.Remove(doc);
        }
    }
