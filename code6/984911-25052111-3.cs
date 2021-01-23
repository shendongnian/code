    // your implementation
    public class MyTestRepository : IRepository<DvaPortalUser>
    {
        public IEnumerable<DvaPortalUser> Query()
        {
           // return some test users (mocks)
           return new List<DvaPortalUser> {new DvaPortalUser(), new DvaPortalUser()};
        }
    }
