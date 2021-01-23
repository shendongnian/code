      public class TestBase
        {
            public IFixture GenerateNewFixture()
            {
                return new Fixture().Customize(new AutoFixtureConventions());
            }
        }
    
     internal class AutoFixtureConventions : CompositeCustomization
        {
            public AutoFixtureConventions() :
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
