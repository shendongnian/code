    internal class TestConventions : CompositeCustomization
    {
        public TestConventions() :
            base(
                new MongoObjectIdCustomization())
        {
        }
        private class MongoObjectIdCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Register(ObjectId.GenerateNewId);
            }
        }
    }
