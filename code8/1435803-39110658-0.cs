    class Document
    {
        public string FileData { get; set; }
        public string FileRelativePath { get; set; }
    }
    interface IDocumentRepository
    {
        Document Get(int id);
    }
    abstract class  DocumentFactory
    {
        public abstract Document Create(int docId);
    }
    interface IFileStore
    {
        string Read(string fileName);
    }
    class ConcreteDocumentFactory : DocumentFactory
    {
        private IDocumentRepository _db;
        private IFileStore _fileStore;
        public ConcreteDocumentFactory(IDocumentRepository db, IFileStore fileStore)
        {
            _db = db;
            _fileStore = fileStore;
        }
        public override Document Create(int docId)
        {
            Document newDoc = _db.Get(docId);
            newDoc.FileData = _fileStore.Read(newDoc.FileRelativePath);
            return newDoc;
        }
    }
    /////// Test Code Below
    [TestFixture]
    class TestClass
    {
        class TestFriendlyFileStore : IFileStore
        {
            public string Read(string fileName)
            {
                if (fileName == "sample.txt")
                    return "Some File Content";
                throw new Exception("Not good file name.");
            }
        }
        class TestFriendlyDocRepo : IDocumentRepository
        {
            public Document Get(int id)
            {
                if (id != 999)
                    return new Document() {FileRelativePath = "sample.txt"};
                throw new Exception("Not good id.");
            }
        }
        [Test]
        public void Test()
        {
            var concreteDocFactory = new ConcreteDocumentFactory(new TestFriendlyDocRepo(), new TestFriendlyFileStore());
            var doc = concreteDocFactory.Create(999);
            Assert.AreEqual(doc.FileData == "Some File Content")
                
        }
    }
