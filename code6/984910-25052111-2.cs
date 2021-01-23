    internal interface IRepository<T>
    {
        IEnumerable<T> Query();
    }
    // your mock
    _UnitOfWork.Setup(a =>  a.Repository<DvaPortalUser>())).Returns(() => new MyTestRepository());
