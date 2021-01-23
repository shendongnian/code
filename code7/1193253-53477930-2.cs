    [TestFixture]
    class QueryControllerTests
    {
        private IOptions<MongoSettings> _mongoSettings;
        private QueryController _queryController;
        private Mock<IFakeMongoCollection> _fakeMongoCollection;
        private Mock<IFindFluent<BsonDocument, BsonDocument>> _fakeCollectionResult;
        [OneTimeSetUp]
        public void Setup()
        {
            _fakeMongoCollection = new Mock<IFakeMongoCollection>();
            _fakeCollectionResult = new Mock<IFindFluent<BsonDocument, BsonDocument>>();
           
        }
    }
