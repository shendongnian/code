    public interface IDocumentCitizenRepository : IRepository<DocumentCitizen>
    { 
        // this interface has no extra methods, just the plain ol' CRUD
    }
    public interface IDocumentResolutionRepository : IRepository<DocumentResolution>
    { 
        // this one can do additional stuff
        void DoSomethingSpecial(DocumentResolution doc);
    }
