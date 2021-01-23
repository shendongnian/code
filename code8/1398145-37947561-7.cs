    public class DraftService : IDraftService
    {
    Container _ctn;
    public DraftService(Container ctn)
    {
        _ctn= ctn;
    }
    public Models.Draft GetByID(long id)
    {
       using(var uow = _ctn.Resolve<IUnitOfWork>()){ // new fresh context. don't forget the AlwaysUnique.
       return uow.Set<Draft>().Find(id); // should return the newer revision.
    }}
    }
