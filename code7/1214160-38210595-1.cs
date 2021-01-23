    public void OpenFromFile();
    public void Save(DocumentModel model);
    public void Edit(DocumentModel model);
 
    public void SetWebServiceState(bool state);
 
    public void SetCurrentElement(DesignerElementTypeA element);
    public void SetCurrentElement(DesignerElementTypeB element);
    public void SetCurrentElement(DesignerElementTypeC element);
 
    public void StartDrawing(MouseEventArgs e);
    public void AddDrawingPoint(MouseEventArgs e);
    public void EndDrawing(MouseEventArgs e);
 
    public class Document
    {
        // Fetches the document service for handling this document
        public DocumentService DocumentService { get; }
    }
 
    public class DocumentService
    {
        public void Save(Document document);
    }
