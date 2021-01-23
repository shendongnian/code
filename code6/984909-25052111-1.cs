    internal interface IRepository<T>
    {
        IEnumerable<T> Query();
    }
    // your mock
    _UnitOfWork.Setup(a =>  a.Repository<DvaPortalUser>())).Returns(() => new MyTestRepository());
    // your implementation
    public class MyTestRepository : IRepository<DvaPortalUser>
    {
        public IEnumerable<DvaPortalUser> Query()
        {
           // return some test users (mocks)
           return new List<DvaPortalUser> {new DvaPortalUser(), new DvaPortalUser()};
        }
    }
