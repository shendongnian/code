    // your mock
    _UnitOfWork.Setup(a =>  a.Repository<DvaPortalUser>())).Returns(() => new MyRepository());
    // your implementation
    public class MyRepository : IRepository<DvaPortalUser>
    {
        public void Query()
        {
        }
    }
