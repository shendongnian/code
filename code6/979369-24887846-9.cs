    // this class will inherit everything from the base abstact class
    public class DocumentCitizenRepository 
       : BaseRepository<DocumentCitizen>, IDocumentCitizenRepository
    { }
    // this class will inherit common methods from the base abstact class,
    // and you will need to implement the rest manually
    public class DocumentResolutionRepository 
       : BaseRepository<DocumentResolution>, IDocumentResolutionRepository
    { 
        public void DoSomethingSpecial(DocumentResolution doc)
        {
            // you still need to code some specific stuff every once in a while
        }
    }
