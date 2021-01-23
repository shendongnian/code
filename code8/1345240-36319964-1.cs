    public abstract class Zoo
    {
        protected IFixture Fixture;
        [Fact]
        public void TestAnimal()
        {
            //Arrange 
            int actualBonesCount = Fixture.BonesCount;
            int expectedBonesCount = 2;
            //Act & Assert
            Assert.Equal(expectedBonesCount, actualBonesCount);
        }
    }
    public class BirdTests : Zoo, IClassFixture<Bird>
    {
        public BirdTests(Bird fixture)
        {
            Fixture = fixture;
        }
    }
    public class TigerTests : Zoo, IClassFixture<Tiger>
    {
        public BirdTests(Tiger fixture)
        {
            Fixture = fixture;
        }
    }
