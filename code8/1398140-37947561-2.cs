        public class DraftService : IDraftService
    {
    IUnitOfWorkResolver _rslv;
    public DraftService(IUnitOfWorkResolver rslv)
    {
        _rslv= rslv;
    }
    public Models.Draft GetByID(long id)
    {
       using(var uow = rslv.GetContext()){ // new fresh context. don't forget the AlwaysUnique.
       return uow.Set<Draft>().Find(id); // should return the newer revision.
    }}
    }
    public class UnitOfWorkResolver{
       public IUnitOfWork GetContext(){
         return new DBContext(); //or whatever you want you could use Container.Resolve<IUnitOFWork>() instead.
       }
    }
