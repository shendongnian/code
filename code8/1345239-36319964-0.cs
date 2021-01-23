    public class Zoo : IClassFixture<Tiger>, IClassFixture<Bird>
    {
        private Bird _bird;
        private Tiger _tiger;
        public Zoo(Tiger tiger, Bird bird)
        {
            _bird = bird;
            _tiger = tiger;
        }
        [Fact]
        public void TestAnimal()
        {
            //Arrange 
            int actualBonesCount = _bird.BonesCount;
            int expectedBonesCount = 2;
            //Act & Assert
            Assert.Equal(expectedBonesCount, actualBonesCount);
        }
    }
