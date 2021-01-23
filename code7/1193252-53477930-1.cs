    public abstract class FakeMongoCollection : IFakeMongoCollection
    {
        public virtual IFindFluent<BsonDocument, BsonDocument> Find(FilterDefinition<BsonDocument> filter, FindOptions options)
        {
            throw new System.NotImplementedException();
        }
    }
