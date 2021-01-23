    public interface IRepository
    {
        IFindFluent<TEntity, TEntity> GetFluent<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, new();
    }
    public class LocationService
    {
        public long CountLocations(IRepository repository)
        {
            return repository.GetFluent<Location>(location => true).Count();
        }
    }
    [TestFixture]
    public class LocationServiceTests
    {
        [Test]
        public void CountLocationsTest()
        {
            const long LocationCount = 5;
            var locationsMock = new Mock<IFindFluent<Location, Location>>();
            locationsMock.Setup(x => x.Count(default(CancellationToken))).Returns(LocationCount);
            var repoMock = new Mock<IRepository>();
            repoMock.Setup(repo => repo.GetFluent(It.IsAny<Expression<Func<Location, bool>>>()))
                    .Returns(locationsMock.Object);
            var locationService = new LocationService();
            long result = locationService.CountLocations(repoMock.Object);
            Assert.AreEqual(LocationCount, result);
        }
    }
