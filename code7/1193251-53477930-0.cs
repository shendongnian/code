    [TestFixture]
    class QueryControllerTests
    {
        private IOptions<MongoSettings> _mongoSettings;
        private QueryController _queryController;
        private Mock<FakeMongoCollection> _fakeMongoCollection;
        private Mock<IFindFluent<BsonDocument, BsonDocument>> _fakeCollectionResult;
        [OneTimeSetUp]
        public void Setup()
        {
            _fakeMongoCollection = new Mock<FakeMongoCollection>();
            _fakeCollectionResult = new Mock<IFindFluent<BsonDocument, BsonDocument>>();
            _fakeMongoCollection.Setup(_ => _.Find(It.IsAny<FilterDefinition<BsonDocument>>(), It.IsAny<FindOptions>()))
                .Returns(_fakeCollectionResult.Object);
        }
    }
