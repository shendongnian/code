    public class MyTests
    {
        [Theory, MyAutoData]
        public void GetThingsByUserId_ShouldReturnThings(IEnumerable<Thing> things)
        {
            things.First().UserId.Should().Be(1);
        }
    }
