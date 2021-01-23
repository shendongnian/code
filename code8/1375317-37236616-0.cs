    public class Some 
    {
        // Mandatory, because a non-optional constructor parameter
        // must be provided or C# compiler will cry
        public Some(IUnitOfWork uow) { ... }
    
        // Optional, because you may or may not set a property
        public IRepository<...> Repo { get; set; }
    }
