    [TestClass]
    public class DocumentServiceTest
    {
        private IDocumentRepository DocumentRepositoryMock { get; set; }
        [TestInitialize]
        public void Initialize()
        {
            DocumentRepositoryMock = MockRepository.GenerateStub<IDocumentRepository>();
        }
        [TestMethod]
        public void Save_ReturnSavedDocument()
        {
            //Arrange
            var repoResult = TestData.AcmeDocumentEntity;
            DocumentRepositoryMock
                .Stub(m => m.Get())
                .IgnoreArguments()
                .Return(new List<EntityModel.Document>() { repoResult }.AsQueryable());
            DocumentRepositoryMock
                .Stub(a => a.Save(null, null))
                .IgnoreArguments()
                .Return(repoResult);
            //Act
            var documentService = CreateDocumentService();
            var savedDocument = documentService.Save(AcmeDocumentModel);
            //Assert that properties are correctly mapped after save        
            AssertEntityEqualsModel(repoResult, savedDocument);
        }
        //Helpers
        private DocumentService CreateDocumentService()
        {
            return new DocumentService(DocumentRepositoryMock);
        }
        private void AssertEntityEqualsModel(EntityModel.Document entityDoc, Models.Document modelDoc)
        {
            Assert.AreEqual(entityDoc.Message, modelDoc.Message);
            Assert.AreEqual(entityDoc.DocumentId, modelDoc.DocumentId);
            //...
        }
    }
    public static class TestData
    {
        public static EntityModel.Document AcmeDocumentEntity
        {
            get
            {
                //Note that a new instance is returned on each invocation:
                return new EntityModel.Document()
                {
                    DocumentId = 2,
                    Message = "TestMessage1",
                    //...
                }
            };
        }
        public static Models.Document AcmeDocumentModel
        {
            get { /* etc. */ }
        }
    }
