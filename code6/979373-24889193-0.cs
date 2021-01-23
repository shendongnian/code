    class DocumentCitizenRepository : DocumentRepository<DocumentCitizen> {
       public override void Save (DocumentCitizen doc) { ... }
       public override IEnumerable<DocumentCitizen> GetDocuments () { ... }
    }
    
    // this class is only meant to simplify implementation
    abstract class DocumentRepository<T> : IDocumentRepository where T: Document {
       public abstract void Save (T doc);
       public abstract IEnumerable<T> GetDocuments ();
       IEnumerable<Document> IDocumentRepository.GetDocuments () { return this.GetDocuments (); }
    }
    
    interface IDocumentRepository {
       IEnumerable<Document> GetDocuments ();
    }
