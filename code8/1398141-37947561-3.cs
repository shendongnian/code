    public class DraftService : IDraftService
    {
    IUnitOfWork _uow; <-- if this is disposed and _draft is accessed you'll get an error.
    IDbSet<Models.Draft> _draft; <-- might be cached.
    public DraftService(IUnitOfWork uow)
    {
        _uow = uow; <--- this context is always the same
        _draft = _uow.Set<Models.Draft>();
    }
    public Models.Draft GetByID(long id)
    {
       return _draft.Find(id); <---- this will always use the cached context.
    }
    }
