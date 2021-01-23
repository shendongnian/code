    public interface IUnitOfWork : IDisposable
    {
        // Commit all the changes 
        void Complete();
        // Concrete implementation -> IRepository<Foo>
        // Add all your repositories here:
        IFooRepository Foos {get;}
    }
